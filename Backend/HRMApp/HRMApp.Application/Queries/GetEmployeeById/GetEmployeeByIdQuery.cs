using HRMApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Application.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery(int idClient,int id) : IRequest<EmployeeDTO>
    {
        public int IdClient { get; set; } = idClient;
        public int Id { get; set; } = id;
    }
}
