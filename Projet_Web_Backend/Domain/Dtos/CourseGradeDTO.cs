using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class CourseGradeDTO
    {
    }
    public class GradeCourseReadDto
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string? StudentName { get; set; }  // Nom de l'étudiant, dérivé de CourseStudent
        public string? AssignmentTitle { get; set; }  // Titre du devoir, dérivé de Assignment
    }
    public class GradeCourseCreateDto
    {
        public int StudentId { get; set; }  // ID étudiant
        public int AssignmentId { get; set; }  // ID du devoir
        public int Grade { get; set; }
    }
    public class GradeCourseUpdateDto
    {
        public int Id { get; set; }
        public int Grade { get; set; }
    }
    public class GradeCourseDetailDto
    {
        public int Id { get; set; }
        public int CourseStudentId { get; set; }
        public string StudentName { get; set; }  // Potentiellement avec plus d'infos sur l'étudiant
        public int AssignmentId { get; set; }
        public string AssignmentTitle { get; set; }
        public string AssignmentDescription { get; set; }
        public int Grade { get; set; }
    }


}
