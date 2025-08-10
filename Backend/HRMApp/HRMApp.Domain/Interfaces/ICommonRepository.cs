using HRMApp.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Domain.Interfaces
{
    public interface ICommonRepository
    {
        //Task<List<DropdownItem>> GetDropdownItemsAsync(string dropdownItem, int idClient);
        Task<List<DropdownItem>> GetAllDepartment(int idClient);
        Task<List<DropdownItem>> GetAllDesignation(int idClient);
        Task<List<DropdownItem>> GetAllEducationExamination(int idClient);
        Task<List<DropdownItem>> GetAllEducationLevel(int idClient);
        Task<List<DropdownItem>> GetAllEducationResult(int idClient);
        Task<List<DropdownItem>> GetAllEmployeeType(int idClient);
        Task<List<DropdownItem>> GetAllGender(int idClient);
        Task<List<DropdownItem>> GetAllJobType(int idClient);
        Task<List<DropdownItem>> GetAllMaritalStatus(int idClient);
        Task<List<DropdownItem>> GetAllRelationship(int idClient);
        Task<List<DropdownItem>> GetAllReligion(int idClient);
        Task<List<DropdownItem>> GetAllSection(int idClient);
        Task<List<DropdownItem>> GetAllWeekOff(int idClient);

    }
}
