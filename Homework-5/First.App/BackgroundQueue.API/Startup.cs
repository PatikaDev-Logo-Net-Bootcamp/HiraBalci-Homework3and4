using BackgroundQueue.API.Background;
using BackgroundQueue.API.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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

namespace BackgroundQueue.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackgroundQueue.API", Version = "v1" });
            });
            //aþaðýda yazdýðým background servis old belirtmem lazým
            services.AddHostedService<BackgroundWorker>();//bu iþlem yapýcak olan background workerý yazdým kuyruk yapýsý olþturdum kullanýcýnýn beklemesi için (kuyruk boþaltma iþlemide yapýyor backgrpund worker)
            //singleton ile beraber queue ekleyeceðim.niye singleton benim için birçok kuyruk olursa yönetemem.tek bir instanst ile yönetmem lazým ki iþler krýþmamalý.
            services.AddSingleton<IBackgroundQueue<Book>, BackgroundQueue<Book>>();

            services.AddScoped<IBookPublisher, BookPublisher>();//yazdýðým interface 'i buraya yazdým.publishi kapsamlý olarak kullan
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackgroundQueue.API v1"));
            }

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
