using Microsoft.Extensions.Options;
using ProtoolsStore.Api.Extensions;
using ProtoolsStore.Api.Middlewares;
using ProtoolsStore.Domain.Configurations;
using ProtoolsStore.Services;
using ProtoolsStore.Services.Mappers;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.TelegramBot;

var builder = WebApplication.CreateBuilder(args);

#region Logger configuration

var logger = new LoggerConfiguration()
    .MinimumLevel.Error()
    .WriteTo.TelegramBot(
        "6475751262:AAGjQy_d41prHgf29fpY3_SLA0cY0kWlvcE", 
        "1400203874",
        "Protools",
        null, 
        LogEventLevel.Verbose,
        null, ParseMode.Markdown)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

#endregion

#region Service collection configuration

// Add services to the containers
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen()
                .AddHttpContextAccessor()
                .AddAutoMapper(typeof(MappingProfile))
                .AddValidatedCors(builder.Configuration)
                .AddSessionStore(builder.Configuration)
                .AddJwtService(builder.Configuration)
                .AddSwaggerService()
                .AddDatabaseSettings(builder.Configuration);

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

// app services using information attached to classes
EnvironmentHelper.WebRootPath = app.Services.GetRequiredService<IWebHostEnvironment>()?.WebRootPath;
if (app.Services.GetService<IHttpContextAccessor>() != null)
    HttpContextHelper.Accessor = app.Services.GetRequiredService<IHttpContextAccessor>();

// some folders created checked
if (!Directory.Exists(EnvironmentHelper.AttachmentPath))
    Directory.CreateDirectory(EnvironmentHelper.AttachmentPath);
if (!Directory.Exists(EnvironmentHelper.FilePath))
    Directory.CreateDirectory(EnvironmentHelper.FilePath);

app.UseHttpsRedirection();  

app.UseCors("GivenDomain");

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.UseExceptionHandlerMiddleware();

app.UseAuthorization();

app.MapControllers();

#endregion 

app.Run();