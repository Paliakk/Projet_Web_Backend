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
        CreateMap<Instructor, InstructorDTO>().ReverseMap();
        CreateMap<Instructor, InstructorCreateDTO>().ReverseMap();
        CreateMap<Instructor, InstructorUpdateDTO>().ReverseMap();
        CreateMap<Student, StudentDTO>().ReverseMap();
        CreateMap<Student, StudentCreateDTO>().ReverseMap();
        CreateMap<Student, StudentUpdateDTO>().ReverseMap();
    }
}