using HRMApp.Domain.Interfaces;
using HRMApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Persistence
{
    public static class DependencyInjection
    {
        //public static IServiceCollection AddPresistenceDI(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddDbContext<HanaHrmContext>(options =>
        //    options.UseSqlServer(configuration.GetConnectionString("con")));

        //    services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        //    services.AddScoped<ICommonRepository, CommonRepository>();

        //    return services;
        //}
    }
}
