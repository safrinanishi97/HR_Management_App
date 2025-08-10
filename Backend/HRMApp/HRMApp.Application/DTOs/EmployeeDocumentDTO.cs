using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Application.DTOs
{
    public class EmployeeDocumentDTO
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdEmployee { get; set; }
        public string DocumentName { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public DateTime UploadDate { get; set; }
        public string? UploadedFileExtention { get; set; }

        public IFormFile? UpFile { get; set; }
        public string? FileBase64 { get; set; }

        public DateTime? SetDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
