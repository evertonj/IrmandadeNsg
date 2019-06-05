using AutoMapper;
using IrmandadeNsg.Application.ViewModels;
using IrmandadeNsg.Domain.Models;

namespace IrmandadeNsg.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Post, PostViewModel>();
        }
    }
}
