using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Application.Commands.DeleteEmployee
{
    public class SoftDeleteEmployeeCommand : IRequest<bool>
    {
        public int IdClient { get; set; }
        public int Id { get; set; }

        public SoftDeleteEmployeeCommand(int idClient, int id)
        {
            IdClient = idClient;
            Id = id;
        }
    }
}
