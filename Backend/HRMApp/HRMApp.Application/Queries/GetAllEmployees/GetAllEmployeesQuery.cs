using HRMApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Application.Queries.GetAllEmployee
{
    //public record GetAllEmployeesQuery(int IdClient) : IRequest<List<EmployeeDTO>>;
    public class GetAllEmployeesQuery: IRequest<List<EmployeeDTO>>
    {
        public int IdClient { get; set; }
        public GetAllEmployeesQuery(int idClient)
        {
            IdClient = idClient;
        }
    }
}
