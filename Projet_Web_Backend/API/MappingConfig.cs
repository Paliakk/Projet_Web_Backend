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
        CreateMap<Assignment, AssignementReadDTO>().ReverseMap();
        CreateMap<Assignment, AssignementCreateDTO>().ReverseMap();
        CreateMap<Assignment, AssignementUpdateDTO>().ReverseMap();
        CreateMap<Assignment, AssignementDetailDTO>().ReverseMap();
        CreateMap<StudentAssignment, StudentAssignmentDTO>().ReverseMap();
        CreateMap<StudentAssignment, StudentAssignmentCreateDTO>().ReverseMap();
        CreateMap<StudentAssignment, StudentAssignmentUpdateDTO>().ReverseMap();
    }
}