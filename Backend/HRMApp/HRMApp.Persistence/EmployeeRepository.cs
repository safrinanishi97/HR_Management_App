using HRMApp.Domain.Entities;
using HRMApp.Domain.Interfaces;
using HRMApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Persistence
{
    public class EmployeeRepository(HanaHrmContext Context) : IEmployeeRepository
    {
        public async Task<List<Employee>> GetAllAsync(int idClient, CancellationToken cancellationToken)
        {
            var emp = await Context.Employees
               .AsNoTracking()
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .Include(e => e.Section)
                .Include(e => e.Gender)
                .Include(e => e.JobType)
                .Include(e => e.EmployeeType)
                .Include(e => e.Religion)
                .Include(e => e.WeekOff)
                .Include(e => e.MaritalStatus)
                .Include(e => e.EmployeeDocuments)
                .Include(e => e.EmployeeEducationInfos)
                    .ThenInclude(eei => eei.EducationLevel)
                .Include(e => e.EmployeeEducationInfos)
                    .ThenInclude(eei => eei.EducationExamination)
                .Include(e => e.EmployeeEducationInfos)
                    .ThenInclude(eei => eei.EducationResult)
                .Include(e => e.EmployeeFamilyInfos)
                    .ThenInclude(efi => efi.Gender)
                .Include(e => e.EmployeeFamilyInfos)
                    .ThenInclude(efi => efi.Relationship)
                .Include(e => e.EmployeeProfessionalCertifications)
               .Where(e => e.IdClient == idClient)
               .ToListAsync(cancellationToken);
            return emp;
        }

        public async Task<Employee?> GetByIdAsync(int idClient, int id, CancellationToken cancellationToken)
        {

            var emp = await Context.Employees
                .AsNoTracking()
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .Include(e => e.Section)
                .Include(e => e.Gender)
                .Include(e => e.JobType)
                .Include(e => e.EmployeeType)
                .Include(e => e.Religion)
                .Include(e => e.WeekOff)
                .Include(e => e.MaritalStatus)
                .Include(e => e.EmployeeDocuments)
                .Include(e => e.EmployeeEducationInfos)
                    .ThenInclude(eei => eei.EducationLevel)
                .Include(e => e.EmployeeEducationInfos)
                    .ThenInclude(eei => eei.EducationExamination)
                .Include(e => e.EmployeeEducationInfos)
                    .ThenInclude(eei => eei.EducationResult)
                .Include(e => e.EmployeeFamilyInfos)
                    .ThenInclude(efi => efi.Gender)
                .Include(e => e.EmployeeFamilyInfos)
                    .ThenInclude(efi => efi.Relationship)
                .Include(e => e.EmployeeProfessionalCertifications)
                .AsSplitQuery()
                .FirstOrDefaultAsync(e => e.IdClient == idClient && e.Id == id, cancellationToken);
            return emp;
        }

        public async Task<bool> CreateAsync(Employee employee, CancellationToken cancellationToken)
        {
            Context.Employees.Add(employee);
            await Context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Employee?> GetByIdForUpdateAsync(int idClient, int id, CancellationToken cancellationToken)
        {
            var existingEmployee = await Context.Employees
                 .Include(e => e.EmployeeDocuments)
                    .Include(e => e.EmployeeEducationInfos)
                    .Include(e => e.EmployeeFamilyInfos)
                    .Include(e => e.EmployeeProfessionalCertifications)
                    .AsSplitQuery()
                .FirstOrDefaultAsync(e => e.IdClient == idClient && e.Id == id, cancellationToken);
            return existingEmployee;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var result = await Context.SaveChangesAsync(cancellationToken);
            return result;
        }
        public async Task<bool> SoftDeleteAsync(int idClient, int id, CancellationToken cancellationToken)
        {
            var affectedRows = await Context.Employees
           .Where(e => e.IdClient == idClient && e.Id == id)
           .ExecuteUpdateAsync(update => update
           .SetProperty(emp => emp.IsActive, false)
           .SetProperty(emp => emp.SetDate, DateTime.Now),
           cancellationToken);

            return affectedRows > 0;
        }

    }
}
