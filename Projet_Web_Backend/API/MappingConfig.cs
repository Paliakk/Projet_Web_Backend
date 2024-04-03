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
    }
}