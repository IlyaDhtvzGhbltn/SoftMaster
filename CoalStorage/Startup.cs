using Contracts.v1.Infrastructure;
using Contracts.v1.Services;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
    public class Startup
    {
        IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<StorageDbContext>(options =>
                options.UseSqlServer(_configuration[AppSettings.ConnectionString]));

            services.AddSingleton<IAreaService>(new AreaService(CreateFactoryDBContext(_configuration)));
            services.AddSingleton<IFactory<StorageDbContext>>(CreateFactoryDBContext(_configuration));
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }


        private static IFactory<StorageDbContext> CreateFactoryDBContext(IConfiguration configuration)
        {
            return new DbFactory<StorageDbContext>(() =>
            {
                var optBuilder = new DbContextOptionsBuilder<StorageDbContext>();
                optBuilder.UseSqlServer(configuration[AppSettings.ConnectionString]);
                optBuilder.EnableSensitiveDataLogging();
                return new StorageDbContext(optBuilder.Options);
            });
        }
    }
}
