using System;
using AutoMapper;
using Newtonsoft.Json;
using NLog.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using RESTful.Catalog.API.Infra.Mapper;
using RESTful.Catalog.API.Infra.Helpers;
using RESTful.Catalog.API.Infra.Filters;
using RESTful.Catalog.API.Infrastructure;
using RESTful.Catalog.API.Utilities.Settings;
using RESTful.Catalog.API.Infrastructure.Abstraction;
using RESTful.Catalog.API.Infrastructure.Repositories;
using RESTful.Catalog.API.Services.Services;
using RESTful.Catalog.API.Services.Abstraction;

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
            #region Autentication

            services.AddMvcCore()
                    .AddAuthorization()
                    .AddJsonFormatters();

            services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = "http://localhost:3000";
                        options.RequireHttpsMetadata = false;
                        options.ApiName = "catalogapi";
                    });

            #endregion

            #region Cors

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                        builder =>
                        {
                            builder.AllowAnyHeader();
                            builder.AllowAnyOrigin();
                            builder.AllowAnyMethod();
                            builder.AllowCredentials();
                        });
            });

            #endregion

            services.AddOptions();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
                     
            services.AddDbContext<CatalogContext>();

            services.AddSingleton<IMapper>(MapperConfig.GetMapper());
  
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<CatalogType, CatalogTypeDto>().ForMember(c => c.Type, f => f.Ignore());
            //    cfg.CreateMap<CatalogType, CatalogTypeDto>().ReverseMap().ForMember(c => c.Type, f => f.Ignore());
            //    cfg.CreateMap<CatalogItem, CatalogItemDto>();
            //    cfg.CreateMap<CatalogItem, CatalogItemForUpdateDto>();
            //    cfg.CreateMap<CatalogItemForUpdateDto, CatalogItem>();
            //});

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

            services.AddTransient<ICatalogService, CatalogService>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();           
            services.AddScoped<IUrlHelper, UrlHelper>(implementationFactory =>
            {
                var actionContext = implementationFactory.GetService<IActionContextAccessor>().ActionContext;

                return new UrlHelper(actionContext);
            });
            
            services.AddScoped<ILinkHelper, LinkHelper>();           

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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
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
          
            MapperExtension.Init(serviceProvider.GetService<IMapper>());

            app.UseStaticFiles();
           
            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog HTTP API V1");
               });

            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Catalog HTTP API");
            });
        }
    }
}
