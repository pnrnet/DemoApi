// <copyright file="Startup.cs" company="Demo Company">
// Copyright (c) Demo Company. All rights reserved.
// </copyright>
// <summary>Startup Calss.</summary>
namespace Demo.Api
{
    using Common.DbHelper;
    using global::Api;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Startup cs file : Executs first when we run the application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Gets initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">set of application configuration properties.</param>
        /// <value>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">set of application configuration properties.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">service collection params.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                             .AllowAnyMethod()
                             .AllowAnyHeader();
            }));

            services.AddMvc(o =>
            {
            });
            services.AddControllers();
            services.AddSingleton<DatabaseOptions>(s => new DatabaseOptions(Configuration.GetConnectionString("BaseConnection")));
            services.AddControllers();
            services.AddSwaggerGen();
            services.ResolveDependency(Configuration);
            services.AddSwaggerGen();
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">class for application request.</param>
        /// <param name="env">provides information about web hosting environment.</param>
        /// <param name="loggerFactory">ILoggerFactory.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo.Api V1");
                c.RoutePrefix = "swagger/ui";
            });
            app.UseCors("CorsPolicy");


            app.UseRouting();
            app.UseCors(x => x
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .SetIsOriginAllowed(origin => true) // allow any origin
                      .AllowCredentials());
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
