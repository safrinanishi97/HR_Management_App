using HRMApp.Application.Commands.CreateEmployee;
using HRMApp.Application.Interfaces;
using HRMApp.Application.Services;
using HRMApp.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HRMApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            //   services.AddMediatR(cfg =>
            //cfg.RegisterServicesFromAssembly(typeof(CreateEmployeeCommandHandler).Assembly));
            //services.AddScoped<ICommonService, CommonService>();

            //services.AddMediatR(cfg =>
            //{
            //    cfg.RegisterServicesFromAssemblyContaining<CreateEmployeeCommand>();
            //});

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); 
               
            });

            return services;
        }
    }
}
