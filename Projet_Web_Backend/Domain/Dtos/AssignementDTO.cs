using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Domain.Dtos.CustomDateTimeConverter;

namespace Domain.Dtos
{
    public class AssignementReadDTO
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }
    }
    public class AssignementReadWithCourseDTO
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Deadline { get; set; }
    }
    public class AssignementCreateDTO
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        private DateTime? _deadline;
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? Deadline
        {
            get => _deadline;
            set
            {
                if (value.HasValue)
                {
                    // Set value to the start of the hour by stripping minutes and seconds
                    _deadline = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day, value.Value.Hour, 0, 0);
                }
                else
                {
                    _deadline = null;
                }
            }
        }
        
    }
    public class AssignementUpdateDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        private DateTime? _deadline;
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? Deadline
        {
            get => _deadline;
            set
            {
                if (value.HasValue)
                {
                    // Set value to the start of the hour by stripping minutes and seconds
                    _deadline = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day, value.Value.Hour, 0, 0);
                }
                else
                {
                    _deadline = null;
                }
            }
        }
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
        public int courseId { get; set; }
        public string CourseName { get; set; }
        public int StudentId { get; set; }
        public string studentName { get; set; }
        public int AssignmentId { get; set; }
        public string assignmentTitle { get; set; }
        public decimal? Grade { get; set; }
        public AssignmentStatus Status { get; set; } // Default status set to Active // Active, Completed, Cancelled
        public string FilePath { get; set; }
    }

    public class StudentAssignmentCreateDTO
    {
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
        [EnumDataType(typeof(AssignmentStatus))]
        public AssignmentStatus Status { get; set; } = AssignmentStatus.Active; // Default status set to Active // Active, Completed, Cancelled
    }

    public class StudentAssignmentUpdateDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
        [EnumDataType(typeof(AssignmentStatus))]
        public AssignmentStatus Status { get; set; }
    }
    public class StudentAssignmentGradeDTO
    {
        public int Id { get; set; }
        [Range(0, 20, ErrorMessage = "La valeur doit être comprise entre 0 et 20")]
        public decimal Grade { get; set; }
    }
    public class StudentAssignmentDetailedDTO
    {
        public int Id { get; set; }
        public int assignmentId { get; set; }
        public string AssignmentTitle { get; set; }
        public string AssignmentDescription { get; set; }
        public DateTime? AssignmentDeadline { get; set; }
        public int StudentId { get; set; }
        public string studentName { get; set; }
        public int courseId { get; set; }
        public string CourseName { get; set; }
        public decimal? Grade { get; set; }
        public decimal? AverageGrade { get; set; }
        public AssignmentStatus Status { get; set; }
        public string FilePath { get; set; }
    }
    public class CourseWithAssignmentsDTO
    {
        public IEnumerable<CourseDTO> Courses { get; set; }
        public IEnumerable<AssignementReadDTO> Assignments { get; set; }
    }
    public class CustomDateTimeConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var dateString = reader.GetString();
                return DateTime.Parse(dateString); // Adaptez cette ligne en fonction de la robustesse nécessaire
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
            {
                // Format ISO sans minutes et secondes, adapté à votre besoin
                writer.WriteStringValue(value.Value.ToString("yyyy-MM-ddTHH:mm:00"));
            }
            else
            {
                writer.WriteNullValue();
            }
        }
        public enum AssignmentStatus
        {
            Active,
            Completed,
            Cancelled,
            Submitted,
            Late
        }
    }
}
