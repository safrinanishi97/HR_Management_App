using HRMApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Application.Commands.DeleteEmployee
{
    public class SoftDeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository) : IRequestHandler<SoftDeleteEmployeeCommand, bool>
    {

        public async Task<bool> Handle(SoftDeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
            {
                return false;
            }

            return await employeeRepository.SoftDeleteAsync(request.IdClient, request.Id, cancellationToken);
        }
    }
}
