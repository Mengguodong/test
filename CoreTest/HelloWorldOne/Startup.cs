using System.IO;
using HelloWorldOne.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWorldOne
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("AppSetting.json");
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFrameworkSqlite().AddDbContext<HelloWorldDbContext>
                (options => options.UseSqlite(Configuration["database:connection"]));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<HelloWorldDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();
            app.UseAuthentication();
            app.UseMvc(ConfigureRoute);
            //app.Run(async (context) =>
            //{
            //    // throw new System.Exception("发生未知错误");
            //    string msg = Configuration["message"];
            //    await context.Response.WriteAsync(msg);
            //});
        }
        public IConfiguration Configuration { get; set; }

        private void ConfigureRoute(IRouteBuilder routeBuilder )
        {
            routeBuilder.MapRoute("Default","{controller=home}/{action=index}/{id?}");
        }
    }
}
