using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Application.DTOs
{
    public class EmployeeProfessionalCertificationDTO
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdEmployee { get; set; }
        public string CertificationTitle { get; set; } = null!;
        public string CertificationInstitute { get; set; } = null!;
        public string InstituteLocation { get; set; } = null!;
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? SetDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
