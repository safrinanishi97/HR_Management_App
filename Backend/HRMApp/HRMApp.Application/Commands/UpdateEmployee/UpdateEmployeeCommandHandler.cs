using HRMApp.Domain.Entities;
using HRMApp.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Application.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<UpdateEmployeeCommand, int>
    {

        public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    throw new Exception($"Data is not found: {nameof(request)}");
                var existingEmployee = await employeeRepository.GetByIdForUpdateAsync(request.IdClient, request.Id, cancellationToken);
                if (existingEmployee == null)
                    return 0;
                var newImage = await ConvertFileToByteArrayAsync(request.ProfileImage, cancellationToken);


                existingEmployee.EmployeeName = request.EmployeeName ?? existingEmployee.EmployeeName;
                existingEmployee.EmployeeNameBangla = request.EmployeeNameBangla ?? existingEmployee.EmployeeNameBangla;
                existingEmployee.FatherName = request.FatherName ?? existingEmployee.FatherName;
                existingEmployee.MotherName = request.MotherName ?? existingEmployee.MotherName;
                if (newImage != null)
                {
                    existingEmployee.EmployeeImage = newImage;
                }
                existingEmployee.IdDesignation = request.IdDesignation ?? existingEmployee.IdDesignation;
                existingEmployee.IdReligion = request.IdReligion ?? existingEmployee.IdReligion;
                existingEmployee.IdGender = request.IdGender ?? existingEmployee.IdGender;
                existingEmployee.IdReportingManager = request.IdReportingManager ?? existingEmployee.IdReportingManager;
                existingEmployee.IdJobType = request.IdJobType ?? existingEmployee.IdJobType;
                existingEmployee.IdEmployeeType = request.IdEmployeeType ?? existingEmployee.IdEmployeeType;
                existingEmployee.IdWeekOff = request.IdWeekOff ?? existingEmployee.IdWeekOff;
                existingEmployee.IdMaritalStatus = request.IdMaritalStatus ?? existingEmployee.IdMaritalStatus;
                existingEmployee.IdDepartment = request.IdDepartment;
                existingEmployee.IdSection = request.IdSection;
                existingEmployee.BirthDate = request.BirthDate ?? existingEmployee.BirthDate;
                existingEmployee.JoiningDate = request.JoiningDate ?? existingEmployee.JoiningDate;
                existingEmployee.Address = request.Address ?? existingEmployee.Address;
                existingEmployee.PresentAddress = request.PresentAddress ?? existingEmployee.PresentAddress;
                existingEmployee.NationalIdentificationNumber = request.NationalIdentificationNumber ?? existingEmployee.NationalIdentificationNumber;
                existingEmployee.ContactNo = request.ContactNo ?? existingEmployee.ContactNo;
                existingEmployee.IsActive = request.IsActive ?? existingEmployee.IsActive;
                existingEmployee.SetDate = DateTime.Now;
                existingEmployee.CreatedBy = request.CreatedBy ?? existingEmployee.CreatedBy; ;

                var docsToRemove = existingEmployee.EmployeeDocuments
                 .Where(ed => ed.IdClient == request.IdClient && !request.Documents.Any(d => d.IdClient == ed.IdClient && d.Id == ed.Id))
                 .ToList();

                foreach (var doc in docsToRemove)
                {
                    existingEmployee.EmployeeDocuments.Remove(doc);
                }

                var eduInfoToRemove = existingEmployee.EmployeeEducationInfos
                    .Where(eei => eei.IdClient == request.IdClient && !request.EducationInfos.Any(ei => ei.IdClient == eei.IdClient && ei.Id == eei.Id))
                    .ToList();
                foreach (var edu in eduInfoToRemove)
                {
                    existingEmployee.EmployeeEducationInfos.Remove(edu);
                }


                var familyInfoToRemove = existingEmployee.EmployeeFamilyInfos
                   .Where(efi => efi.IdClient == request.IdClient && !request.FamilyInfos.Any(ef => ef.IdClient == efi.IdClient && ef.Id == efi.Id))
                   .ToList();

                foreach (var fam in familyInfoToRemove)
                {
                    existingEmployee.EmployeeFamilyInfos.Remove(fam);
                }

                var certificateToRemove = existingEmployee.EmployeeProfessionalCertifications
                    .Where(epc => epc.IdClient == request.IdClient && !request.Certifications.Any(c => c.IdClient == epc.IdClient && c.Id == epc.Id))
                    .ToList();

                foreach (var cert in certificateToRemove)
                {
                    existingEmployee.EmployeeProfessionalCertifications.Remove(cert);
                }



                foreach (var item in request.Documents)
                {
                    var existingEntry = existingEmployee.EmployeeDocuments.FirstOrDefault(ed => ed.IdClient == item.IdClient && ed.Id == item.Id && ed.Id > 0);
                    byte[]? uploadedBytes = null;
                    string? extension = null;

                    if (item.UpFile != null)
                    {
                        uploadedBytes = await ConvertFileToByteArrayAsync(item.UpFile, cancellationToken);
                        extension = Path.GetExtension(item.UpFile.FileName);
                    }

                    if (existingEntry != null)
                    {
                        existingEntry.DocumentName = item.DocumentName;
                        existingEntry.FileName = item.FileName;
                        existingEntry.UploadDate = item.UploadDate;
                        existingEntry.UploadedFileExtention = extension ?? item.UploadedFileExtention;
                        if (uploadedBytes != null)
                        {
                            existingEntry.UploadedFile = uploadedBytes;
                        }
                        existingEntry.SetDate = DateTime.Now;
                    }
                    else
                    {
                        var newEmployeeDocument = new EmployeeDocument()
                        {
                            IdClient = item.IdClient,
                            IdEmployee = existingEmployee.Id,
                            DocumentName = item.DocumentName,
                            FileName = item.FileName,
                            UploadDate = item.UploadDate,
                            UploadedFileExtention = extension,
                            UploadedFile = uploadedBytes,
                            SetDate = DateTime.Now
                        };

                        existingEmployee.EmployeeDocuments.Add(newEmployeeDocument);
                    }
                }
               

                foreach (var item in request.EducationInfos)
                {
               
                    var existingEntry = existingEmployee.EmployeeEducationInfos
                        .FirstOrDefault(ei => ei.IdClient == item.IdClient && ei.Id == item.Id && ei.Id > 0);

                    if (existingEntry != null)
                    {
                  
                        existingEntry.IdEducationLevel = item.IdEducationLevel;
                        existingEntry.IdEducationExamination = item.IdEducationExamination;
                        existingEntry.IdEducationResult = item.IdEducationResult;
                        existingEntry.Cgpa = item.Cgpa;
                        existingEntry.ExamScale = item.ExamScale;
                        existingEntry.Marks = item.Marks;
                        existingEntry.PassingYear = item.PassingYear;
                        existingEntry.InstituteName = item.InstituteName;
                        existingEntry.Major = item.Major;
                        existingEntry.IsForeignInstitute = item.IsForeignInstitute;
                        existingEntry.Duration = item.Duration;
                        existingEntry.Achievement = item.Achievement;
                        existingEntry.SetDate = DateTime.Now;
                    }
                    else
                    {
                   
                        var newEmployeeEducationInfo = new EmployeeEducationInfo()
                        {
                            IdClient = item.IdClient,
                            IdEmployee = existingEmployee.Id,
                            IdEducationLevel = item.IdEducationLevel,
                            IdEducationExamination = item.IdEducationExamination,
                            IdEducationResult = item.IdEducationResult,
                            Cgpa = item.Cgpa,
                            ExamScale = item.ExamScale,
                            Marks = item.Marks,
                            PassingYear = item.PassingYear,
                            InstituteName = item.InstituteName,
                            Major = item.Major,
                            IsForeignInstitute = item.IsForeignInstitute,
                            Duration = item.Duration,
                            Achievement = item.Achievement,
                            SetDate = DateTime.Now
                        };

                        existingEmployee.EmployeeEducationInfos.Add(newEmployeeEducationInfo);
                    }
                }


                foreach (var item in request.FamilyInfos)
                {
                    var existingEntry = existingEmployee.EmployeeFamilyInfos.FirstOrDefault(ei => ei.IdClient == item.IdClient && ei.Id == item.Id && ei.Id > 0);
                    if (existingEntry != null)
                    {
                        existingEntry.IdGender = item.IdGender;
                        existingEntry.IdRelationship = item.IdRelationship;
                        existingEntry.Name = item.Name;
                        existingEntry.DateOfBirth = item.DateOfBirth;
                        existingEntry.ContactNo = item.ContactNo;
                        existingEntry.CurrentAddress = item.CurrentAddress;
                        existingEntry.PermanentAddress = item.PermanentAddress;
                        existingEntry.SetDate = DateTime.Now;
                    }
                    else
                    {
                        var newEmployeeFamilyInfo = new EmployeeFamilyInfo()
                        {
                            IdClient = item.IdClient,
                            IdEmployee = existingEmployee.Id,
                            IdGender = item.IdGender,
                            IdRelationship = item.IdRelationship,
                            Name = item.Name,
                            DateOfBirth = item.DateOfBirth,
                            ContactNo = item.ContactNo,
                            CurrentAddress = item.CurrentAddress,
                            PermanentAddress = item.PermanentAddress,
                            SetDate = DateTime.Now
                        };

                        existingEmployee.EmployeeFamilyInfos.Add(newEmployeeFamilyInfo);
                    }
                }


                foreach (var item in request.Certifications)
                {
                    var existingEntry = existingEmployee.EmployeeProfessionalCertifications.FirstOrDefault(ei => ei.IdClient == item.IdClient && ei.Id == item.Id && ei.Id > 0);
                    if (existingEntry != null)
                    {
                        existingEntry.CertificationTitle = item.CertificationTitle;
                        existingEntry.CertificationInstitute = item.CertificationInstitute;
                        existingEntry.InstituteLocation = item.InstituteLocation;
                        existingEntry.FromDate = item.FromDate;
                        existingEntry.ToDate = item.ToDate;
                        existingEntry.SetDate = DateTime.Now;
                    }
                    else
                    {
                        var newCertification = new EmployeeProfessionalCertification
                        {
                            IdClient = item.IdClient,
                            IdEmployee = existingEmployee.Id,
                            CertificationTitle = item.CertificationTitle,
                            CertificationInstitute = item.CertificationInstitute,
                            InstituteLocation = item.InstituteLocation,
                            FromDate = item.FromDate,
                            ToDate = item.ToDate,
                            SetDate = DateTime.Now
                        };
                        existingEmployee.EmployeeProfessionalCertifications.Add(newCertification);
                    }
                }

                var result = await employeeRepository.SaveChangesAsync(cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
          

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
