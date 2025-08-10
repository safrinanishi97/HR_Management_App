using HRMApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllAsync(int idClient, CancellationToken cancellationToken);
    Task<bool> CreateAsync(Employee employee, CancellationToken cancellationToken);

    Task<Employee?> GetByIdAsync(int idClient, int id, CancellationToken cancellationToken);

    Task<Employee?> GetByIdForUpdateAsync(int idClient, int id, CancellationToken cancellationToken);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    Task<bool> SoftDeleteAsync(int idClient, int id, CancellationToken cancellationToken);
}
