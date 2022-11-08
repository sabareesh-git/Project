using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2
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
            try
            {
                services.AddMvc();
                services.AddDbContext<CRUDContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CRUDContext")));
                services.AddCors(cors => cors.AddPolicy("MyPolicy", builder => {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                }));
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("V1",
                        new Microsoft.OpenApi.Models.OpenApiInfo
                        {
                            Title = "Employee Management API - Swager",
                            Description = "Employee Management API Using Swagger",
                            Version = "V1"
                        });
                });

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/V1/swagger.json", "Employee Application v1"));
            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
