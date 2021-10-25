using AutoMapper;
using Fenix.ESender.API.Data;
using Fenix.ESender.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Fenix.ESender.API
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
            services.AddSingleton<IConnectionFactory, SqlConnectionFactory>(service =>
            {
                return new SqlConnectionFactory(Configuration.GetConnectionString("SqlConnection"));
            });

            //Add seed data

            //Repository
            services.AddTransient<ICampaignRepository, CampaignRepository>();
            services.AddTransient<ICampaignMessageRepository, CampaignMessageRepository>();

            //Services
            services.AddTransient<ICampaignService, CampaignService>();
            services.AddTransient<ICampaignMessageService, CampaignMessageService>();

            services.AddAutoMapper(typeof(Startup));

            // Register the Swagger Generator service
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Newsletter API",
                    Version = "v1",
                    Description = "Endpoints for the API Newsletter. This is just for API test and code discussions. ",
                    Contact = new OpenApiContact
                    {
                        Name = "Tiago Fenix",
                        Email = "tiagofenixbarros@gmail.com"
                    },
                });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Newsletter API V1");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = string.Empty;
            });

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
