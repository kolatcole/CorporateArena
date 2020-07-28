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




            //   services.Add
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Corporate Arena API"
                });
            });










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



            
            services.AddDbContext<TContext>(opt => {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("CorporateArena.Presentation.Core"));
            });

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
