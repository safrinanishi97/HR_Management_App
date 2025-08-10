using HRMApp.Application.Interfaces;
using HRMApp.Domain.Interfaces;
using HRMApp.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Application.Services
{
    public class CommonService(ICommonRepository CommonRepository) : ICommonService
    {
        public async Task<List<CommonViewModel>> GetAllDepartment(int idClient)
        {
            var items = await CommonRepository.GetAllDepartment(idClient);
            return items.Select(i => new CommonViewModel { Id = i.Id, Text = i.Name }).ToList();
        }

        public async Task<List<CommonViewModel>> GetAllDesignation(int idClient)
        {
            var items = await CommonRepository.GetAllDesignation(idClient);
            return items.Select(i => new CommonViewModel { Id = i.Id, Text = i.Name }).ToList();
    
        }

        public async Task<List<CommonViewModel>> GetAllEducationExamination(int idClient)
        {
            var items = await CommonRepository.GetAllEducationExamination(idClient);
            return items.Select(i => new CommonViewModel { Id = i.Id, Text = i.Name }).ToList();

        }

        public async Task<List<CommonViewModel>> GetAllEducationLevel(int idClient)
        {
            var items = await CommonRepository.GetAllEducationLevel(idClient);
            return items.Select(i => new CommonViewModel { Id = i.Id, Text = i.Name }).ToList();
        }

        public async Task<List<CommonViewModel>> GetAllEducationResult(int idClient)
        {
            var items = await CommonRepository.GetAllEducationResult(idClient);
            return items.Select(i => new CommonViewModel { Id = i.Id, Text = i.Name }).ToList();
        }

        public async Task<List<CommonViewModel>> GetAllEmployeeType(int idClient)
        {
            var items = await CommonRepository.GetAllEmployeeType(idClient);
            return items.Select(i => new CommonViewModel { Id = i.Id, Text = i.Name }).ToList();
        }

        public async Task<List<CommonViewModel>> GetAllGender(int idClient)
        {
            var items = await CommonRepository.GetAllGender(idClient);
            return items.Select(i => new CommonViewModel { Id = i.Id, Text = i.Name }).ToList();
        }

        public async Task<List<CommonViewModel>> GetAllJobType(int idClient)
        {
            var items = await CommonRepository.GetAllJobType(idClient);
            return items.Select(i => new CommonViewModel { Id = i.Id, Text = i.Name }).ToList();
        }

        public async Task<List<CommonViewModel>> GetAllMaritalStatus(int idClient)
        {
            var items = await CommonRepository.GetAllMaritalStatus(idClient);
            return items.Select(i => new CommonViewModel { Id = i.Id, Text = i.Name }).ToList();
        }

        public async Task<List<CommonViewModel>> GetAllRelationship(int idClient)
        {
            var items = await CommonRepository.GetAllRelationship(idClient);
            return items.Select(i => new CommonViewModel { Id = i.Id, Text = i.Name }).ToList();
        }

        public async Task<List<CommonViewModel>> GetAllReligion(int idClient)
        {
            var items = await CommonRepository.GetAllReligion(idClient);
            return items.Select(i => new CommonViewModel { Id = i.Id, Text = i.Name }).ToList();
        }

        public async Task<List<CommonViewModel>> GetAllSection(int idClient)
        {
            var items = await CommonRepository.GetAllSection(idClient);
            return items.Select(i => new CommonViewModel { Id = i.Id, Text = i.Name }).ToList();
        }

        public async Task<List<CommonViewModel>> GetAllWeekOff(int idClient)
        {
            var items = await CommonRepository.GetAllWeekOff(idClient);
            return items.Select(i => new CommonViewModel { Id = i.Id, Text = i.Name }).ToList();
        }

        //public async Task<List<CommonViewModel>> GetDropdownAsync(string type, int clientId)
        //{
        //    var data = await CommonRepository.GetDropdownItemsAsync(type, clientId);
        //    return data.Select(d => new CommonViewModel { Id = d.Id, Text = d.Name }).ToList();
        //}
    }
}
