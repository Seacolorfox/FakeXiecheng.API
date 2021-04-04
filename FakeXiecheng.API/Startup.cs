using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeXiecheng.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FakeXiecheng.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //注册数据仓库的服务依赖，接口为ITouristRouteRepository，实现为MockTouristRouteRepository
            //AddTransient()会在每次请求时创建一个全新的数据仓库，请求结束以后会注销仓库
            services.AddTransient<ITouristRouteRepository, MockTouristRouteRepository>();
            //AddSingleton()在启动时仅创建一个仓库，每次请求会使用同一个实例（共用）。简单易用便于管理，内存占用小 
            //services.AddSingleton
            //介于AddTransient与AddScoped之间，同时引入了事务管理的概念。有且仅创建一个仓库 结束后销毁
            //services.AddScoped
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/test", async context =>
                //{
                //    await context.Response.WriteAsync("Hello from test!");
                //});
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllers();
            });
        }
    }
}
