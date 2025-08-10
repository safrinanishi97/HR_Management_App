using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Application.DTOs
{
    public class EmployeeEducationInfoDTO
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdEmployee { get; set; }
        public int IdEducationLevel { get; set; }
        public string? EducationLevelName { get; set; }
        public int IdEducationExamination { get; set; }
        public string? ExamName { get; set; }
        public int IdEducationResult { get; set; }
        public string? ResultName { get; set; }
        public decimal? Cgpa { get; set; }
        public decimal? ExamScale { get; set; }
        public decimal? Marks { get; set; }
        public string Major { get; set; } = null!;
        public decimal PassingYear { get; set; }
        public string InstituteName { get; set; } = null!;
        public bool IsForeignInstitute { get; set; }
        public decimal? Duration { get; set; }
        public string? Achievement { get; set; }
        public DateTime? SetDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
