using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorporateArena.Domain;
using CorporateArena.Infrastructure;
using CorporateArena.Presentation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CorporateArena
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            var JwtOptSection = Configuration.GetSection(nameof(JwtOpt));
            services.Configure<JwtOpt>(JwtOptSection);
            var jwtOpt = JwtOptSection.Get<JwtOpt>();

            var key = jwtOpt.Secret;
            var exTime = jwtOpt.ExpiryTime;

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt=> {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer=false,
                    ValidateAudience=false,
                    ValidateIssuerSigningKey=false,
                    RequireExpirationTime=true
                };
            });



            services.AddControllers();
            services.AddDbContext<TContext>(opt => {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("CorporateArena.Presentation.Core"));
            });

            services.AddScoped<IPermissionRepo, PermissionRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IPrivilegeRepo, PrivilegeRepo>();
            services.AddScoped<IRepo<Role>, RoleRepo>();


            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IUserService, UserService>();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
