using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Authentication.Server.Configuration;
using Microsoft.EntityFrameworkCore;
using Authentication.Server.Data;
using Authentication.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;

namespace Authentication.Server
{
    /* Moved project folder */
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
            services.AddDbContext<ApplicationDbContext>(options =>
                                  options.UseSqlServer(Configuration["AuthSettings:ConnectionString"]));

            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc(
                   setupAction =>
                   {
                       setupAction.ReturnHttpNotAcceptable = true;
                       setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                       setupAction.InputFormatters.Add(new XmlDataContractSerializerInputFormatter(setupAction));                      
                   })
                  .AddJsonOptions(options =>
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddIdentityServer()              
                    .AddDeveloperSigningCredential()
                    .AddInMemoryIdentityResources(Config.GetIdentityResources())
                    .AddInMemoryApiResources(Config.GetApiResources())
                    .AddInMemoryClients(Config.GetClients())
                    .AddTestUsers(Config.GetUsers());

            services.AddOptions();
            services.Configure<AuthSettings>(Configuration.GetSection("AuthSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Authentication Server");
            });
        }
    }
}
