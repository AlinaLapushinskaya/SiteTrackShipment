using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Repository;
using Repository.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiteTrackShipment.Controllers;
using SiteTrackShipment.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SiteTrackShipment.ViewModels;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.ImpUser;
using Repository.Interfaces;

namespace SiteTrackShipment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDbContext<DeliveryContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));

            services.AddScoped<ICarriers, CarriersController>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IUserService, UserService>();
            //services.AddScoped<IUsers, UsersController>();



            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = AuthOption.ISSUER,
                            ValidateAudience = true,
                            ValidAudience = AuthOption.AUDIENCE,
                            ValidateLifetime = true,
                            IssuerSigningKey = AuthOption.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                        };
                    });

            services.AddMvc();


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

    }
}
