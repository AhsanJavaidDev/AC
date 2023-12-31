using System;
using AutoMapper;
using AcmeCorp.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeCorp.Services.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(AutoMapperConfig.RegisterMappings());

            //services.AddAutoMapper(typeof(Startup));
            //services.AddAutoMapper(Assembly.GetAssembly(this.GetType()));
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
            //services.AddAutoMapper(cfg =>
            //{
            //    cfg.AddProfile(new DomainToViewModelMappingProfile());
            //    cfg.AddProfile(new ViewModelToDomainMappingProfile());
            //}, Assembly.GetExecutingAssembly());

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            //AutoMapperConfig.RegisterMappings();
        }
    }
}
