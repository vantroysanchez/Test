using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Test.Helpers;
using Test.Models.Context;

namespace Test
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
            services.AddCors(options =>
            {
                options.AddPolicy(name: "OriginsApp",
                              policy =>
                              {
                                  policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                              });
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "Web/client/dist";
            });

            services.AddControllers().AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test", Version = "v1" });
            });
            services.AddDbContext<dbTestSqlServerContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<dbTestMySqlContext>(options =>
                        options.UseMySQL(Configuration.GetConnectionString("MySqlConnection")));

            services.AddScoped<ApplicationDbContextInitialiser>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test v1"));

                app.UseMigrationsEndPoint();

                // Initialise and seed database
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
                    initialiser.InitialiseAsync();
                }
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseCors("OriginsApp");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "Web/client";

                if (env.IsDevelopment())
                {
                    spa.UseNuxtDevelopmentServer();
                    //spa.UseProxyToSpaDevelopmentServer("https://localhost:3000");
                }
            });
        }
    }
}
