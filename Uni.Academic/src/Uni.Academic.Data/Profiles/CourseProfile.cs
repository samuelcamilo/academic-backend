using AutoMapper;
using System.Linq;
using Uni.Academic.Core.Models;
using Uni.Academic.Shared.ViewModels;

namespace Uni.Academic.Data.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Resume, opt => opt.MapFrom(src => src.Resume));
                // .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.CourseSubjects.Select(x => x.Subject)));
        }
    }
}
