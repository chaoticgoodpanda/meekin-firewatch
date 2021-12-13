using System.Linq;
using Application.Events;
using AutoMapper;
using Domain;
using Domain.Facebook;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PostLabeling, PostLabeling>();
            CreateMap<Post, Post>();
            // to map from PostLabeling to the PL DTO
            CreateMap<PostLabeling, PostLabelingDto>()
                .ForMember(d => d.AuthorUsername,
                    o =>
                        o.MapFrom(s => s.Reporters.FirstOrDefault(x => x.IsAuthor).User.UserName));
            CreateMap<ReportReporter, Profiles.Profile>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.User.DisplayName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.User.UserName))
                .ForMember(d => d.Organization, o => o.MapFrom(s => s.User.Organization))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.User.Image))
                .ForMember(d => d.Bio, o => o.MapFrom(s => s.User.Bio));
            CreateMap<Post, PostDto>();
            CreateMap<PostFollower, Profiles.Profile>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.User.DisplayName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.User.UserName))
                .ForMember(d => d.Organization, o => o.MapFrom(s => s.User.Organization))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.User.Image))
                .ForMember(d => d.Bio, o => o.MapFrom(s => s.User.Bio));        
        }
    }
}