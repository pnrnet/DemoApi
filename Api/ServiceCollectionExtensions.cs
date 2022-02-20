// <copyright file="ServiceCollectionExtensions.cs" company="Demo Company">
// Copyright (c) Demo Company. All rights reserved.
// </copyright>
// <summary>Service Collection Extension Class for resolve dependency.</summary>

namespace Demo.Api
{
    using Common.DbHelper;
    using Demo.Data.Abstract;
    using Demo.Data.Concrete;
    using Demo.Service.Abstract;
    using Demo.Service.Concrete;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Partial static Class ServiceCollectionExtensions : Class includes extension method related to service.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Dependency Injection.
        /// </summary>
        /// <param name="services">collection of services.</param>
        public static void ResolveDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DatabaseOptions>(s => new DatabaseOptions(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDbHelper, DbHelper>();
            services.AddScoped(typeof(IStudentRepository), typeof(StudentRepository));
            services.AddScoped(typeof(IStudentService), typeof(StudentService));
            
        }
    }
}
