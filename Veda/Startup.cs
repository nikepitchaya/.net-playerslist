using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayersList.Data;
using mytask.Handler;
using PlayersList.Repository;
using MyTask.BusinessFlow;
using PlayersList.Flow;
using PlayersList.Logic;
using PlayersList.Service.User;
using PlayersList.Service.Game;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using PlayersList.Service.Player;

namespace mytask
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = Configuration.GetConnectionString("postgres");
            var sqlConnectionStringReadOnly = Configuration.GetConnectionString("postgresReadOnly");

            //Context
            services.AddScoped<MainContext>();
            services.AddDbContext<MainContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("postgres")
                ));

            //Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["Jwt:Issuer"],
                   ValidAudience = Configuration["Jwt:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
               });

            //Flow
            services.AddScoped<HealthCheckBusinessFlow>();
            services.AddScoped<UserFlow>();
            services.AddScoped<GameFlow>();
            services.AddScoped<PlayerFlow>();
            //Logic
            services.AddScoped<UserLogic>();
            services.AddScoped<GameLogic>();
            services.AddScoped<PlayerLogic>();
            //Service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IPlayerService, PlayerService>();
            //Repository
            services.AddScoped<IBaseRepository, BaseRepository>();

            //Cors
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000")
                                          .AllowAnyHeader()
                                          .AllowAnyOrigin()
                                          .AllowAnyMethod();
                                  });
            });

            //Controllers
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(option => option.SetIsOriginAllowed(x => _ = true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
