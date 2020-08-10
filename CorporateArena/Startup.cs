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
using Microsoft.OpenApi.Models;

namespace CorporateArena
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
       // public const string SendGridKey = "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";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            string SendgridKey = Configuration.GetSection("Sendgrid")["ApiKey"];

            services.AddControllers();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Test Api",
                    Version = "v1"
                });

                //First we define the security scheme
                opt.AddSecurityDefinition("Bearer", //Name the security scheme
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
                        Scheme = "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
                    });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement{
                     {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                            Id = "Bearer", //The name of the previously defined security scheme.
                            Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                });

            });
                //   services.Add
            //    services.AddSwaggerGen(opt =>
            //{
            //    opt.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "Corporate Arena API"
            //    });
            //});










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
                opt.SaveToken = true;
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer=false,
                    ValidateAudience=false,
                    ValidateLifetime=true,
                    ValidateIssuerSigningKey=true
                };
            });

            services.AddEntityFrameworkNpgsql().AddDbContext<TContext>(opt =>
            {
                opt.UseNpgsql(Configuration.GetConnectionString("PostgreConnection"), b => b.MigrationsAssembly("CorporateArena.Presentation.Core"));
            });


            //services.AddDbContext<TContext>(opt => {
            //    opt.UseSqlServer(Configuration.GetConnectionString("PostgreConnection"), b => b.MigrationsAssembly("CorporateArena.Presentation.Core"));
            //});

            services.AddScoped <IRepo<RolePrivilege> ,RolePrivilegeRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IPrivilegeRepo, PrivilegeRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IRepo<BrainTeaser>, BrainTeaserRepo>();
            services.AddScoped<IRepo<BrainTeaserAnswer>, BrainTeaserAnswerRepo>();
            services.AddScoped<IArticleRepo, ArticleRepo>();
            services.AddScoped<IRepo<ArticleComment>, ArticleCommentRepo>();
            services.AddScoped<IArticleLikeRepo, ArticleLikeRepo > ();
            services.AddScoped<ICommentLikeRepo, CommentLikeRepo>();
            services.AddScoped<IRepo<TrafficUpdate>, TrafficUpdateRepo>();
            services.AddScoped<IRepo<TrafficComment>, TrafficCommentRepo>();
            services.AddScoped<IVacancyRepo, VacancyRepo>();
            services.AddScoped<IRepo<Contact>, ContactRepo>();
            services.AddScoped<IUserRoleRepo, UserRoleRepo>();
            


            services.AddTransient<IEmailSender>(a => new EmailSender(SendgridKey));
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBrainTeaserService, BrainTeaserService>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<ITrafficUpdateService, TrafficUpdateService>();
            services.AddTransient<IVacancyService, VacancyService>();
            services.AddTransient<IPrivilegeService, PrivilegeService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var swaggerOpt = new SwaggerOpt();
            Configuration.GetSection(nameof(SwaggerOpt)).Bind(swaggerOpt);
            app.UseSwagger(opt => {
                opt.RouteTemplate = swaggerOpt.JsonRoute;
            });
            app.UseSwaggerUI(opt => {
                opt.SwaggerEndpoint(swaggerOpt.UIEndPoint, swaggerOpt.Description);
            });

            app.UseHttpsRedirection();
        }
    }
}
