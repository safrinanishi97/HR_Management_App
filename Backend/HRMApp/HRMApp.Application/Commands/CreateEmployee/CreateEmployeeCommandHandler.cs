using HRMApp.Domain.Entities;
using HRMApp.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Application.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<CreateEmployeeCommand, int>
    {

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
             var employee = new Employee
            {
                IdClient = request.IdClient,
                EmployeeName = request.EmployeeName,
                EmployeeNameBangla = request.EmployeeNameBangla,
                FatherName = request.FatherName,
                MotherName = request.MotherName,
                EmployeeImage = await ConvertFileToByteArrayAsync(request.ProfileImage,cancellationToken),
                IdDepartment = request.IdDepartment,
                IdReportingManager = request.Id,
                IdJobType=request.IdJobType,
                IdEmployeeType=request.IdEmployeeType,
                IdGender=request.IdGender,
                IdReligion=request.IdReligion,
                IdDesignation=request.IdDesignation,
                IdWeekOff=request.IdWeekOff,
                IdMaritalStatus=request.IdMaritalStatus,
                IdSection = request.IdSection,
                BirthDate = request.BirthDate,
                JoiningDate = request.JoiningDate,
                Address = request.Address,
                PresentAddress = request.PresentAddress,
                NationalIdentificationNumber = request.NationalIdentificationNumber,
                ContactNo = request.ContactNo,
                IsActive = true,
                HasOvertime = request.HasOvertime ?? false,
                HasAttendenceBonus = request.HasAttendenceBonus ?? false,
                SetDate = DateTime.Now,
                CreatedBy=request.CreatedBy,
                //EmployeeDocuments = (await Task.WhenAll(
                //employeeDto.Documents.Select(async doc =>
                //{
                //    var uploadedBytes = await ConvertFileToByteArrayAsync(doc.UpFile);
                //    var extension = Path.GetExtension(doc.UpFile?.FileName);

                //    return new EmployeeDocument
                //    {
                //        IdClient = doc.IdClient,
                //        DocumentName = doc.DocumentName,
                //        FileName = doc.FileName,
                //        UploadDate = doc.UploadDate,
                //        UploadedFileExtention = extension,
                //        UploadedFile = uploadedBytes,
                //        SetDate = DateTime.Now
                //    };
                //})
                //)).ToList(),
                EmployeeDocuments =new List<EmployeeDocument>(),


                EmployeeEducationInfos = request.EducationInfos
                .Select(e => new EmployeeEducationInfo
                {
                    IdClient = e.IdClient,
                    IdEducationLevel = e.IdEducationLevel,
                    IdEducationExamination = e.IdEducationExamination,
                    IdEducationResult = e.IdEducationResult,
                    Cgpa = e.Cgpa,
                    ExamScale = e.ExamScale,
                    Marks = e.Marks,
                    Major = e.Major,
                    PassingYear = e.PassingYear,
                    InstituteName = e.InstituteName,
                    IsForeignInstitute = e.IsForeignInstitute,
                    Duration = e.Duration,
                    Achievement = e.Achievement,
                    SetDate = DateTime.Now
                }).ToList(),

                EmployeeFamilyInfos = request.FamilyInfos
                .Select(e => new EmployeeFamilyInfo
                {
                    IdClient = e.IdClient,
                    IdGender = e.IdGender,
                    IdRelationship = e.IdRelationship,
                    Name = e.Name,
                    ContactNo = e.ContactNo,
                    DateOfBirth = e.DateOfBirth,
                    CurrentAddress = e.CurrentAddress,
                    PermanentAddress = e.PermanentAddress,
                    SetDate = DateTime.Now
                }).ToList(),

                EmployeeProfessionalCertifications = request.Certifications
                .Select(c => new EmployeeProfessionalCertification
                {
                    IdClient = c.IdClient,
                    CertificationTitle = c.CertificationTitle,
                    CertificationInstitute = c.CertificationInstitute,
                    InstituteLocation = c.InstituteLocation,
                    FromDate = c.FromDate,
                    ToDate = c.ToDate,
                    SetDate = DateTime.Now
                }).ToList()
            };


            foreach (var doc in request.Documents)
            {
                var uploadedBytes = await ConvertFileToByteArrayAsync(doc.UpFile, cancellationToken);
                var extension = Path.GetExtension(doc.UpFile?.FileName);
                employee.EmployeeDocuments.Add(new EmployeeDocument
                {
                    IdClient = doc.IdClient,
                    DocumentName = doc.DocumentName,
                    FileName = doc.FileName,
                    UploadDate = doc.UploadDate,
                    UploadedFileExtention = extension,
                    UploadedFile = uploadedBytes,
                    SetDate = DateTime.Now
                });
            }
            await employeeRepository.CreateAsync(employee, cancellationToken);
            return employee.Id;
        }
        private async Task<byte[]?> ConvertFileToByteArrayAsync(IFormFile? file, CancellationToken cancellationToken)
        {
            if (file == null || file.Length == 0)
                return null;

            const long maxFileSize = 10 * 1024 * 1024;

            if (file.Length > maxFileSize)
                throw new Exception("File size cannot exceed 10 MB.");

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream, cancellationToken);
            return memoryStream.ToArray();
        }
    }
}
