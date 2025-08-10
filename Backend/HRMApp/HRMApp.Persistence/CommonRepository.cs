using HRMApp.Domain.Interfaces;
using HRMApp.Domain.ViewModels;
using HRMApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Persistence
{
    public class CommonRepository(HanaHrmContext Context) : ICommonRepository
    {
        public async Task<List<DropdownItem>> GetAllDepartment(int idClient)
        {

            var dept = await Context.Departments
                .AsNoTracking()
                .Where(d => d.IdClient == idClient)
                .Select(e => new DropdownItem
                {
                    Id = e.Id,
                    Name = e.DepartName
                }).ToListAsync();
            return dept;
        }


        public async Task<List<DropdownItem>> GetAllDesignation(int idClient)
        {
            var designation = await Context.Designations
                .AsNoTracking()
                .Where(d => d.IdClient == idClient)
                .Select(e => new DropdownItem
                {
                    Id = e.Id,
                    Name = e.DesignationName
                }).ToListAsync();
            return designation;
        }

        public async Task<List<DropdownItem>> GetAllEducationExamination(int idClient)
        {
            var eduExam = await Context.EducationExaminations
                .AsNoTracking()
                 .Where(d => d.IdClient == idClient)
                .Select(e => new DropdownItem
                {
                    Id = e.Id,
                    Name = e.ExamName
                }).ToListAsync();
            return eduExam;
        }

        public async Task<List<DropdownItem>> GetAllEducationLevel(int idClient)
        {
            var eduLevel = await Context.EducationLevels
                .AsNoTracking()
                 .Where(d => d.IdClient == idClient)
                .Select(e => new DropdownItem
                {
                    Id = e.Id,
                    Name = e.EducationLevelName
                }).ToListAsync();
            return eduLevel;
        }

        public async Task<List<DropdownItem>> GetAllEducationResult(int idClient)
        {
            var eduResult = await Context.EducationResults
                .AsNoTracking()
                 .Where(d => d.IdClient == idClient)
                .Select(e => new DropdownItem
                {
                    Id = e.Id,
                    Name = e.ResultName
                }).ToListAsync();
            return eduResult;
        }

        public async Task<List<DropdownItem>> GetAllEmployeeType(int idClient)
        {
            var empType = await Context.EmployeeTypes
                .AsNoTracking()
                 .Where(d => d.IdClient == idClient)
                .Select(e => new DropdownItem
                {
                    Id = e.Id,
                    Name = e.TypeName ?? ""
                }).ToListAsync();
            return empType;
        }

        public async Task<List<DropdownItem>> GetAllGender(int idClient)
        {
            var gender = await Context.Genders
                .AsNoTracking()
                 .Where(d => d.IdClient == idClient)
                .Select(e => new DropdownItem
                {
                    Id = e.Id,
                    Name = e.GenderName ?? ""
                }).ToListAsync();
            return gender;
        }

        public async Task<List<DropdownItem>> GetAllJobType(int idClient)
        {
            var jobType = await Context.JobTypes
                .AsNoTracking()
                 .Where(d => d.IdClient == idClient)
                .Select(e => new DropdownItem
                {
                    Id = e.Id,
                    Name = e.JobTypeName
                }).ToListAsync();
            return jobType;
        }

        public async Task<List<DropdownItem>> GetAllMaritalStatus(int idClient)
        {
            var maritalStatus = await Context.MaritalStatuses
                .AsNoTracking()
                 .Where(d => d.IdClient == idClient)
                .Select(e => new DropdownItem
                {
                    Id = e.Id,
                    Name = e.MaritalStatusName
                }).ToListAsync();
            return maritalStatus;

        }

        public async Task<List<DropdownItem>> GetAllRelationship(int idClient)
        {
            var relation = await Context.Relationships
                .AsNoTracking()
                 .Where(d => d.IdClient == idClient)
                .Select(e => new DropdownItem
                {
                    Id = e.Id,
                    Name = e.RelationName
                }).ToListAsync();
            return relation;
        }

        public async Task<List<DropdownItem>> GetAllReligion(int idClient)
        {
            var religion = await Context.Religions
                .AsNoTracking()
                 .Where(d => d.IdClient == idClient)
                .Select(e => new DropdownItem
                {
                    Id = e.Id,
                    Name = e.ReligionName
                }).ToListAsync();
            return religion;
        }

        public async Task<List<DropdownItem>> GetAllSection(int idClient)
        {
            var section = await Context.Sections
                .AsNoTracking()
                .Where(d => d.IdClient == idClient)
                .Select(e => new DropdownItem
                {
                    Id = e.Id,
                    Name = e.SectionName ?? ""
                }).ToListAsync();
            return section;
        }

        public async Task<List<DropdownItem>> GetAllWeekOff(int idClient)
        {
            var weekOff = await Context.WeekOffs
                .AsNoTracking()
                 .Where(d => d.IdClient == idClient)
                .Select(e => new DropdownItem
                {
                    Id = e.Id,
                    Name = e.WeekOffDay ?? ""
                }).ToListAsync();
            return weekOff;
        }

        //public async Task<List<DropdownItem>> GetDropdownItemsAsync(string dropdownType, int idClient)
        //{
        //    var normalizedType = dropdownType?.Trim().ToLowerInvariant();

        //    IQueryable<DropdownItem> query = normalizedType switch
        //    {
        //        "department" => Context.Departments
        //            .Where(x => x.IdClient == idClient)
        //            .Select(x => new DropdownItem { Id = x.Id, Name = x.DepartName }),

        //        "designation" => Context.Designations
        //            .Where(x => x.IdClient == idClient)
        //            .Select(x => new DropdownItem { Id = x.Id, Name = x.DesignationName }),

        //        "educationlevel" => Context.EducationLevels
        //            .Where(x => x.IdClient == idClient)
        //            .Select(x => new DropdownItem { Id = x.Id, Name = x.EducationLevelName }),

        //        "educationexamination" => Context.EducationExaminations
        //            .Where(x => x.IdClient == idClient)
        //            .Select(x => new DropdownItem { Id = x.Id, Name = x.ExamName }),

        //        "educationresult" => Context.EducationResults
        //            .Where(x => x.IdClient == idClient)
        //            .Select(x => new DropdownItem { Id = x.Id, Name = x.ResultName }),

        //        "employeetype" => Context.EmployeeTypes
        //            .Where(x => x.IdClient == idClient)
        //            .Select(x => new DropdownItem { Id = x.Id, Name = x.TypeName ?? "" }),

        //        "gender" => Context.Genders
        //            .Where(x => x.IdClient == idClient)
        //            .Select(x => new DropdownItem { Id = x.Id, Name = x.GenderName ?? "" }),

        //        "jobType" => Context.JobTypes
        //            .Where(x => x.IdClient == idClient)
        //            .Select(x => new DropdownItem { Id = x.Id, Name = x.JobTypeName }),

        //        "maritalStatus" => Context.MaritalStatuses
        //            .Where(x => x.IdClient == idClient)
        //            .Select(x => new DropdownItem { Id = x.Id, Name = x.MaritalStatusName }),

        //        "relationship" => Context.Relationships
        //            .Where(x => x.IdClient == idClient)
        //            .Select(x => new DropdownItem { Id = x.Id, Name = x.RelationName }),

        //        "religion" => Context.Religions
        //            .Where(x => x.IdClient == idClient)
        //            .Select(x => new DropdownItem { Id = x.Id, Name = x.ReligionName }),

        //        "section" => Context.Sections
        //           .Where(x => x.IdClient == idClient)
        //           .Select(x => new DropdownItem { Id = x.Id, Name = x.SectionName }),

        //        "weekoff" => Context.WeekOffs
        //           .Where(x => x.IdClient == idClient)
        //           .Select(x => new DropdownItem { Id = x.Id, Name = x.WeekOffDay ?? "" }),

        //        _ => Enumerable.Empty<DropdownItem>().AsQueryable()
        //    };
        //    return await query.AsNoTracking().ToListAsync();
        //}



    }
}
