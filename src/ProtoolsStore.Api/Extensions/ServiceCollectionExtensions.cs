using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProtoolsStore.Domain.Configurations;
using ProtoolsStore.Data.DbContexts;
using ProtoolsStore.Data.IRepositories;
using ProtoolsStore.Data.Repositories;
using ProtoolsStore.Domain.Entities;
using ProtoolsStore.Services.Interfaces;
using ProtoolsStore.Services.Services;

namespace ProtoolsStore.Api.Extensions;

public static class CollectionServiceExtensions
{
    public static IServiceCollection AddSessionStore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions()
                .Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));
        
        // Register custom services in there ...
        services.AddScoped<IRepository<Attachment>, Repository<Attachment>>();
        services.AddScoped<IRepository<Contact>, Repository<Contact>>();
        services.AddScoped<IRepository<Tour>, Repository<Tour>>();
        services.AddScoped<IRepository<Order>, Repository<Order>>();
        services.AddScoped<IRepository<Blog>, Repository<Blog>>();

        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<ITourService, TourService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IBlogService, BlogService>();

        return services;
    }

    public static IServiceCollection AddValidatedCors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(cfg =>
        {
            cfg.AddPolicy("GivenDomain", policy =>
            {
                policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins(configuration["AllowedOrigins"]!.Split(" "));
            });
        });

        return services;
    }

    public static IServiceCollection AddDatabaseSettings(
        this IServiceCollection services, IConfiguration configuration)
    {
   
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration["ConnectionStrings:DefaultConnection"], optionsBuilder =>
                optionsBuilder.MigrationsAssembly("ProtoolsStore.Data")));

        return services;
    }
    
    #region Jwt Service

    public static IServiceCollection AddJwtService(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("Jwt");
        string key = jwtSettings.GetSection("Key")?.Value;
        
        if (string.IsNullOrEmpty(key))
        {
            throw new InvalidOperationException("Jwt key is missing or invalid.");
        }

        serviceCollection.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };
        });

        return serviceCollection;
    }

    #endregion
    
    #region Setup Swagger
    public static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);


            c.SwaggerDoc("v1", new OpenApiInfo { Title = "NFU.Backend.Discussion.Api", Version = "v1" });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
        return services;
    }
    #endregion
}