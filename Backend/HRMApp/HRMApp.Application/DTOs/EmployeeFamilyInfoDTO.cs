using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Application.DTOs
{
    public class EmployeeFamilyInfoDTO
    {
        public int IdClient { get; set; }
        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public string Name { get; set; } = null!;
        public int IdGender { get; set; }
        public string? GenderName { get; set; }
        public int IdRelationship { get; set; }
        public string? RelationName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ContactNo { get; set; }
        public string? CurrentAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public DateTime? SetDate { get; set; }
        public string? CreatedBy { get; set; }

    }
}
