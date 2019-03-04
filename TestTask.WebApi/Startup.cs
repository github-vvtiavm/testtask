using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Buisness;
using TestTask.Buisness.Abstract;
using TestTask.Buisness.Models;
using TestTask.Common.Abstract;
using TestTask.Common.Entities;
using TestTast.Data;

namespace TestTask.WebApi
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
            services.AddMvc();
            services.AddScoped<IDbContext, DataContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrderBusiness, OrderBusiness>();
            services.AddDbContext<DataContext>(options => options.UseNpgsql(Configuration["ConnectionString"]));
            Mapping();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<IDbContext>();
                context.EnsureCreated();
            }
        }

        public void Mapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<OrderModel, Order>().ForMember(x => x.SourceTimeZone, y => y.Ignore());
                cfg.CreateMap<Order, OrderModel>();
            });
        }

    }
}
