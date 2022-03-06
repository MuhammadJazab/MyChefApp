using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyChefApi.Services;
using MyChefAppModels;
using Utilities;

namespace MyChefApi
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

            services.AddDbContext<MyChefContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("MyChefApiContext"), builder => builder.EnableRetryOnFailure()));

            services.AddScoped<IIdentityServices, IdentityServices>();
            services.AddScoped<IAdminServices, AdminServices>();
            services.AddScoped<IUnitOfWork, UnitOfWork<MyChefContext>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();

            app.UseMvc(endpoints =>
            {
                endpoints.MapRoute(
                    name: "default",
                    template: "api/{controller}/{action}/{id?}");
            });
        }
    }
}
