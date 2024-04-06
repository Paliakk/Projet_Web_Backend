using AutoMapper;
using Domain.Dtos;
using Domain.Models;
namespace API;
public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Course,CourseDTO>().ReverseMap();
        CreateMap<Course, CourseCreateDTO>().ReverseMap();
        CreateMap<Course, CourseUpdateDTO>().ReverseMap();
        CreateMap<CourseDTO, CourseUpdateDTO>().ReverseMap();
        CreateMap<ApplicationUser, UserUpdateDTO>().ReverseMap();
        CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        CreateMap<ApplicationUser, UserAddDTO>().ReverseMap();
    }
}