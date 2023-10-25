using AutoMapper;
using ProtoolsStore.Domain.Entities;
using ProtoolsStore.Services.DTOs;
using ProtoolsStore.Services.ViewModels.Blogs;
using ProtoolsStore.Services.ViewModels.Contacts;
using ProtoolsStore.Services.ViewModels.Order;
using ProtoolsStore.Services.ViewModels.Tours;

namespace ProtoolsStore.Services.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TourForCreationDTO, Tour>();
        CreateMap<BlogForCreationDTO, Blog>();
        CreateMap<OrderForCreationDTO, Order>();
        CreateMap<ContactForCreationDTO, Contact>();
        CreateMap<Contact, ContactViewModel>();
        CreateMap<Order, OrderViewModel>();
        CreateMap<Tour, TourViewModel>()
            .ForMember(vm => vm.ImagePath, u => u.MapFrom(src => src.Attachment.Path == null ? null : src.Attachment!.Path));
        CreateMap<Blog, BlogViewModel>()
            .ForMember(vm => vm.ImagePath, u => u.MapFrom(src => src.Attachment.Path == null ? null : src.Attachment!.Path));
    }
}