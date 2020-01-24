using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
using IdentityServer4.AccessTokenValidation;
using FakeGladiatus.Application.Manager;

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
            var configuration = Configuration.Get<AppSettings>();
            services.AddControllers();
            services.AddSignalR();
            services.AddDbContext<DbContext, FakeGladiatusDbContext>(x => x.UseSqlServer(configuration.DatabaseConnectionString));
            services.AddScoped<IRepository<UserDbEntity>, BaseRepository<UserDbEntity>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRepository<CharacterDbEntity>, BaseRepository<CharacterDbEntity>>();
            services.AddScoped<IRepository<NotificationDbEntity>, BaseRepository<NotificationDbEntity>>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IAttackSystemService, AttackSystemService>();
            services.AddScoped<FightManager>();
            services.AddCors();
            services.AddAutoMapper(typeof(MapperAutoProfile));
            services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
            {
                options.Authority = configuration.AuthorizationAddress;
                options.RequireHttpsMetadata = false;
                options.Audience = "gladiatusapi";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/NotificationHub");
            });
        }
    }
}
