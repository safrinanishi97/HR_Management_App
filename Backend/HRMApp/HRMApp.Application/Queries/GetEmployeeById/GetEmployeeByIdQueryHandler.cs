using HRMApp.Application.DTOs;
using HRMApp.Domain.Interfaces;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Application.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeeByIdQuery, EmployeeDTO>
    {

        public async Task<EmployeeDTO> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
		
                var employee = await employeeRepository.GetByIdAsync(request.IdClient, request.Id, cancellationToken);
                if (employee == null) return null;
                cancellationToken.ThrowIfCancellationRequested();
                var employeeDto = new EmployeeDTO
                {
                    Id = employee.Id,
                    IdClient = employee.IdClient,
                    EmployeeName = employee.EmployeeName,
                    EmployeeNameBangla = employee.EmployeeNameBangla,
                    FatherName = employee.FatherName,
                    MotherName = employee.MotherName,
                    BirthDate = employee.BirthDate,
                    IdDepartment = employee.IdDepartment,
                    IdReportingManager = employee.IdReportingManager,
                    IdJobType = employee.IdJobType,
                    IdEmployeeType = employee.IdEmployeeType ?? null,
                    IdGender = employee.IdGender ?? null,
                    IdReligion = employee.IdReligion ?? null,
                    IdDesignation = employee.IdDesignation ?? null,
                    IdSection = employee.IdSection,
                    IdWeekOff = employee.IdWeekOff ?? null,
                    IdMaritalStatus = employee.IdMaritalStatus ?? null,
                    DepartmentName = employee.Department.DepartName ?? "",
                    ReportingManager = employee.EmployeeName,
                    JobTypeName = employee.JobType?.JobTypeName ?? "",
                    TypeName = employee.EmployeeType?.TypeName ?? "",
                    GenderName = employee.Gender?.GenderName ?? "",
                    ReligionName = employee.Religion?.ReligionName ?? "",
                    Designation = employee.Designation?.DesignationName ?? "",
                    SectionName = employee.Section.SectionName ?? "",
                    JoiningDate = employee.JoiningDate,
                    Address = employee.Address,
                    PresentAddress = employee.PresentAddress,
                    NationalIdentificationNumber = employee.NationalIdentificationNumber,
                    ContactNo = employee.ContactNo,
                    HasOvertime = employee.HasOvertime ?? false,
                    HasAttendenceBonus = employee.HasAttendenceBonus ?? false,
                    WeekOffDay = employee.WeekOff?.WeekOffDay ?? "",
                    IsActive = employee.IsActive,
                    MaritalStatusName = employee.MaritalStatus?.MaritalStatusName ?? "",
                    CreatedBy = employee.CreatedBy ?? "",
                    FileBase64 = employee.EmployeeImage != null ? Convert.ToBase64String(employee.EmployeeImage) : null,



                    Documents = employee.EmployeeDocuments
                    .Select(d => new EmployeeDocumentDTO
                    {
                        Id = d.Id,
                        IdClient = d.IdClient,
                        DocumentName = d.DocumentName,
                        FileName = d.FileName,
                        UploadDate = d.UploadDate,
                        UploadedFileExtention = d.UploadedFileExtention,
                        FileBase64 = d.UploadedFile != null ? Convert.ToBase64String(d.UploadedFile) : null,

                    }).ToList(),

                    EducationInfos = employee.EmployeeEducationInfos
                    .Select(e => new EmployeeEducationInfoDTO
                    {
                        Id = e.Id,
                        IdClient = e.IdClient,
                        IdEducationLevel = e.IdEducationLevel,
                        EducationLevelName = e.EducationLevel?.EducationLevelName ?? "",
                        IdEducationExamination = e.IdEducationExamination,
                        ExamName = e.EducationExamination?.ExamName ?? "",
                        IdEducationResult = e.IdEducationResult,
                        ResultName = e.EducationResult?.ResultName ?? "",
                        Cgpa = e.Cgpa,
                        ExamScale = e.ExamScale,
                        Marks = e.Marks,
                        Major = e.Major,
                        PassingYear = e.PassingYear,
                        InstituteName = e.InstituteName,
                        IsForeignInstitute = e.IsForeignInstitute,
                        Duration = e.Duration,
                        Achievement = e.Achievement
                    }).ToList(),


                    FamilyInfos = employee.EmployeeFamilyInfos
                    .Select(e => new EmployeeFamilyInfoDTO
                    {
                        Id = e.Id,
                        IdClient = e.IdClient,
                        IdGender = e.IdGender,
                        IdRelationship = e.IdRelationship,
                        Name = e.Name,
                        GenderName = e.Gender?.GenderName ?? "",
                        RelationName = e.Relationship?.RelationName ?? "",
                        ContactNo = e.ContactNo,
                        DateOfBirth = e.DateOfBirth,
                        CurrentAddress = e.CurrentAddress,
                        PermanentAddress = e.PermanentAddress,
                    }).ToList(),

                    Certifications = employee.EmployeeProfessionalCertifications
                    .Select(c => new EmployeeProfessionalCertificationDTO
                    {
                        Id = c.Id,
                        IdClient = c.IdClient,
                        CertificationTitle = c.CertificationTitle,
                        CertificationInstitute = c.CertificationInstitute,
                        InstituteLocation = c.InstituteLocation,
                        FromDate = c.FromDate,
                        ToDate = c.ToDate
                    }).ToList()
                };
                return employeeDto;
            
        }
    }
}
