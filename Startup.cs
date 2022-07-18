using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atelier.Domain.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Atelier.Domain.Abstract;
using Newtonsoft.Json;

namespace Atelier
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
            services.AddDbContext<AtelierDbContext>(a => a.UseInMemoryDatabase(databaseName: "AtelierDatabase"));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Atelier", Version = "v1" });
            });
            services.AddScoped<IRepository, AtelierRepos>();
        }

        public void Configure(IApplicationBuilder   app
                            , IWebHostEnvironment   env
                            , IConfiguration        conf
                            , AtelierDbContext      context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Atelier v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            string dataText = System.IO.File.ReadAllText(conf["DataSourceFile"]);
            SeedData.InitData(context, dataText);
        }
    }
}
