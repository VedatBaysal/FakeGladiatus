using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeGladiatus.Application.Entities.DbEntities;
using FakeGladiatus.Application.Repositories;
using FakeGladiatus.Application.Services;
using FakeGladiatus.Application.Services.Interfaaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FakeGladiatus
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //Data Source=.;Initial Catalog=FakeGladiatus;Integrated Security=True
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<FakeGladiatusDbContext>(x => x.UseSqlServer("Data Source=.;Initial Catalog=FakeGladiatus;Integrated Security=True"));
            services.AddDbContext<DbContext, FakeGladiatusDbContext>(x => x.UseSqlServer("Data Source=.;Initial Catalog=FakeGladiatus;Integrated Security=True"));
            services.AddScoped<IRepository<UserDbEntity>, BaseRepository<UserDbEntity>>();
            services.AddScoped<IUserService, UserService>();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
