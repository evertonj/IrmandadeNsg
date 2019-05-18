using AutoMapper;
using IrmandadeNsg.Application.ViewModels;
using IrmandadeNsg.Domain.Commands;

namespace IrmandadeNsg.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PostViewModel, RegisterNewPostCommand>()
                .ConstructUsing(p => new RegisterNewPostCommand(p.Title, p.Body, p.Image, p.Image, p.Tags, p.Category, p.Created, p.MainComments));
            CreateMap<PostViewModel, UpdatePostCommand>()
                .ConstructUsing(p => new UpdatePostCommand(p.Id, p.Title, p.Body, p.Image, p.Image, p.Tags, p.Category, p.Created, p.MainComments));
        }
    }
}
