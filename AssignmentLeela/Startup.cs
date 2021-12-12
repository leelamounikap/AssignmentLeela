using AssignmentLeela.Manager;
using AssignmentLeela.POCO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AssignmentLeela
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        protected IServiceCollection ServiceCollection { get; set; }
        protected CorsSettings CorsSettings { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<ICardManager, CardManager>();
            var corsSection = Configuration.GetSection("Cors");
            CorsSettings = corsSection.Get<CorsSettings>();
            ServiceCollection = services;
            RegisterCorsPolicies();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AssignmentAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                { 
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AssignmentAPI v1");
                    c.RoutePrefix = string.Empty;
                });
            }
            app.UseCors(CorsSettings?.Policy ?? string.Empty);
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseMvc(b =>
            //{
            //    b.EnableDependencyInjection(s => s.AddService(ServiceLifetime.Singleton, typeof(ODataUriResolver),
            //        typeof(UnqualifiedCallAndEnumPrefixFreeResolver)));
            //});

        }
        private void RegisterCorsPolicies()
        {
            ServiceCollection.AddCors(options =>
            {
                if (CorsSettings == null) return;

                var origins = CorsSettings?.AllowedHosts.Split(',');

                options.AddPolicy(CorsSettings.Policy,
                    builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
            });
        }
    }
}
