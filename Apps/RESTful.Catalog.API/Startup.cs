using AutoMapper;
using Newtonsoft.Json;
using NLog.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RESTful.Catalog.API.Infra.Models;
using RESTful.Catalog.API.Infrastructure;
using RESTful.Catalog.API.Infrastructure.Models;
using RESTful.Catalog.API.Infrastructure.Abstraction;
using RESTful.Catalog.API.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using RESTful.Catalog.API.Infra.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace RESTful.Catalog.API
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
        //    services.AddDbContext<CatalogContext>(options =>
        //                 options.UseSqlServer(Configuration["ConnectionString"]));
            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
          
            services.AddDbContext<CatalogContext>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CatalogType, CatalogTypeDto>();
                cfg.CreateMap<CatalogItem, CatalogItemDto>();
                cfg.CreateMap<CatalogItem, CatalogItemForUpdateDto>();
                cfg.CreateMap<CatalogItemForUpdateDto, CatalogItem>();
            });

            services.AddMvc(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                setupAction.InputFormatters.Add(new XmlDataContractSerializerInputFormatter(setupAction));
                setupAction.Filters.Add(typeof(HttpGlobalExceptionFilter));
                setupAction.Filters.Add(typeof(ValidateModelStateFilter));                
            })
            .AddJsonOptions(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);                              

            services.AddScoped<ICatalogRepository, CatalogRepository>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();           
            services.AddScoped<IUrlHelper, UrlHelper>(implementationFactory =>
                 {
                     var actionContext = implementationFactory.GetService<IActionContextAccessor>().ActionContext;

                     return new UrlHelper(actionContext);
                 });

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Info
                {
                    Title = "RESTFul.Catalog.API - Catalog HTTP API",
                    Version = "v1",
                    Description = "The Catalog Microservice HTTP API.",
                    TermsOfService = "Terms Of Service"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {             
                app.UseHsts();
            }          

            app.UseStaticFiles();         

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });

            app.UseHttpsRedirection();
            app.UseMvc();          
        }
    }
}
