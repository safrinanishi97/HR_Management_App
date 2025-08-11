using HRMApp.Application.DTOs;
using HRMApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Application.Queries.GetAllEmployee
{
    public class GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetAllEmployeesQuery, List<EmployeeDTO>>
    {

        public async Task<List<EmployeeDTO>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await employeeRepository.GetAllAsync(request.IdClient, cancellationToken);
            var result = employees.Where(e => e.IdClient == request.IdClient && e.IsActive == true)
               .Select(e => new EmployeeDTO
               {
                   Id = e.Id,
                   IdClient = e.IdClient,
                   EmployeeName = e.EmployeeName,
                   EmployeeNameBangla = e.EmployeeNameBangla,
                   FatherName = e.FatherName,
                   MotherName = e.MotherName,
                   BirthDate = e.BirthDate,
                   IdDepartment = e.IdDepartment,
                   DepartmentName = e.Department.DepartName ?? "",
                   IdReportingManager = e.IdReportingManager,
                   ReportingManager = e.EmployeeName,
                   IdJobType = e.IdJobType,
                   JobTypeName = e.JobType?.JobTypeName ?? "",
                   IdEmployeeType = e.IdEmployeeType ?? null,
                   TypeName = e.EmployeeType?.TypeName ?? "",
                   IdGender = e.IdGender ?? null,
                   GenderName = e.Gender?.GenderName ?? "",
                   IdReligion = e.IdReligion ?? null,
                   ReligionName = e.Religion?.ReligionName ?? "",
                   IdDesignation = e.IdDesignation ?? null,
                   Designation = e.Designation?.DesignationName ?? "",
                   IdSection = e.IdSection,
                   SectionName = e.Section.SectionName ?? "",
                   JoiningDate = e.JoiningDate,
                   Address = e.Address,
                   PresentAddress = e.PresentAddress,
                   NationalIdentificationNumber = e.NationalIdentificationNumber,
                   ContactNo = e.ContactNo,
                   HasOvertime = e.HasOvertime ?? false,
                   HasAttendenceBonus = e.HasAttendenceBonus ?? false,
                   IdWeekOff = e.IdWeekOff ?? null,
                   WeekOffDay = e.WeekOff?.WeekOffDay ?? "",
                   IsActive = e.IsActive,
                   IdMaritalStatus = e.IdMaritalStatus ?? null,
                   MaritalStatusName = e.MaritalStatus?.MaritalStatusName ?? "",
                   CreatedBy = e.CreatedBy ?? "",
                   FileBase64 = e.EmployeeImage != null ? Convert.ToBase64String(e.EmployeeImage) : null,
                   //FileBase64 = e.EmployeeImage != null ? $"data:image/jpeg;base64,{Convert.ToBase64String(e.EmployeeImage)}" : null,
                   Documents = e.EmployeeDocuments
                    .Select(d => new EmployeeDocumentDTO
                    {
                        Id = d.Id,
                        IdClient = d.IdClient,
                        DocumentName = d.DocumentName,
                        FileName = d.FileName,
                        UploadDate = d.UploadDate,
                        UploadedFileExtention = d.UploadedFileExtention,
                        FileBase64 = d.UploadedFile != null ? Convert.ToBase64String(d.UploadedFile) : null,
                        //FileBase64 = d.UploadedFile != null ? $"data:image/jpeg;base64,{Convert.ToBase64String(d.UploadedFile)}" : null,
                        SetDate = d.SetDate ?? null,
                        CreatedBy = d.CreatedBy,

                    }).ToList(),

                   EducationInfos = e.EmployeeEducationInfos
                .Select(ed => new EmployeeEducationInfoDTO
                {
                    Id = ed.Id,
                    IdClient = ed.IdClient,
                    IdEducationLevel = ed.IdEducationLevel,
                    EducationLevelName = ed.EducationLevel?.EducationLevelName ?? "",
                    IdEducationExamination = ed.IdEducationExamination,
                    ExamName = ed.EducationExamination?.ExamName ?? "",
                    IdEducationResult = ed.IdEducationResult,
                    ResultName = ed.EducationResult?.ResultName ?? "",
                    Cgpa = ed.Cgpa,
                    ExamScale = ed.ExamScale,
                    Marks = ed.Marks,
                    Major = ed.Major,
                    PassingYear = ed.PassingYear,
                    InstituteName = ed.InstituteName,
                    IsForeignInstitute = ed.IsForeignInstitute,
                    Duration = ed.Duration,
                    Achievement = ed.Achievement,
                    SetDate = ed.SetDate ?? null,
                    CreatedBy = ed.CreatedBy,

                }).ToList(),

                   FamilyInfos = e.EmployeeFamilyInfos
                .Select(e => new EmployeeFamilyInfoDTO
                {
                    Id = e.Id,
                    IdClient = e.IdClient,
                    IdGender = e.IdGender,
                    IdRelationship = e.IdRelationship,
                    GenderName = e.Gender?.GenderName ?? "",
                    RelationName = e.Relationship?.RelationName ?? "",
                    Name = e.Name,
                    ContactNo = e.ContactNo,
                    DateOfBirth = e.DateOfBirth,
                    CurrentAddress = e.CurrentAddress,
                    PermanentAddress = e.PermanentAddress,
                    SetDate = e.SetDate ?? null,
                    CreatedBy = e.CreatedBy,
                }).ToList(),

                   Certifications = e.EmployeeProfessionalCertifications
                .Select(c => new EmployeeProfessionalCertificationDTO
                {
                    Id = c.Id,
                    IdClient = c.IdClient,
                    CertificationTitle = c.CertificationTitle,
                    CertificationInstitute = c.CertificationInstitute,
                    InstituteLocation = c.InstituteLocation,
                    FromDate = c.FromDate,
                    ToDate = c.ToDate,
                    SetDate = c.SetDate ?? null,
                    CreatedBy = c.CreatedBy ?? null,
                }).ToList()

               }).ToList();
            return result;
        }
    }
}
