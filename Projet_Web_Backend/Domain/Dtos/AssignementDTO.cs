using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class AssignementReadDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
    public class AssignementCreateDTO
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
    public class AssignementUpdateDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
    public class AssignementDetailDTO
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
    public class StudentAssignmentDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string studentName { get; set; }
        public int AssignmentId { get; set; }
        public string assignmentTitle { get; set; }
        public int? Grade { get; set; }
    }

    public class StudentAssignmentCreateDTO
    {
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
    }

    public class StudentAssignmentUpdateDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
    }
    public class StudentAssignmentGradeDTO
    {
        public int Id { get; set; }
        [Range(0, 20, ErrorMessage = "La valeur doit être comprise entre 0 et 20")]
        public int Grade { get; set; }
    }
}
