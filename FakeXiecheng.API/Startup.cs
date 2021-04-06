using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeXiecheng.API.Database;
using FakeXiecheng.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace FakeXiecheng.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }//�ڹ��������ж��丳ֵ
        //���÷�������ע�루appsettings.json��
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //ע�����ݲֿ�ķ����������ӿ�ΪITouristRouteRepository��ʵ��ΪMockTouristRouteRepository
            //AddTransient()����ÿ������ʱ����һ��ȫ�µ����ݲֿ⣬��������Ժ��ע���ֿ�
            services.AddTransient<ITouristRouteRepository, TouristRouteRepository>();
            //AddSingleton()������ʱ������һ���ֿ⣬ÿ�������ʹ��ͬһ��ʵ�������ã��������ñ��ڹ����ڴ�ռ��С 
            //services.AddSingleton
            //����AddTransient��AddScoped֮�䣬ͬʱ�������������ĸ�����ҽ�����һ���ֿ� ����������
            //services.AddScoped

            //�������Ķ���ע��IOC����,���������ݿ�����
            services.AddDbContext<AppDbContext>(option =>{
                //option.UseSqlServer("server=localhost:1433;Database=FakeXiechengDb;User Id = sa; Password=123456;");
                option.UseSqlServer(Configuration["DbContext:ConnectionString"]);
            });
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
