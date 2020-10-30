using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeWidgetSignUp.Data;
using AcmeWidgetSignUp.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AcmeWidgetSignUp
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
            var connectionString = Configuration.GetConnectionString("ActivitySignUp");
            services.AddDbContext<ActivitySignUpContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IInterestedPersonRepository, InterestedPersonRepository>();

            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            var origins = new string[] { "http://localhost:4200" };

            if (origins.Any())
            {
                services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy", builder =>
                        builder.WithOrigins(origins)
                            .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
                });
            }
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

            //app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
