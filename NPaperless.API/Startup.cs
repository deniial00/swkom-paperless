/*
 * Mock Server
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NPaperless.API.Authentication;
using NPaperless.API.Filters;
using NPaperless.API.OpenApi;
using NPaperless.API.Formatters;
using AutoMapper;
using Microsoft.Extensions.Logging;
using NPaperless.BL.Interfaces;
using NPaperless.BL;
using NPaperless.BL.Entities;
using FluentValidation;
using NPaperless.DA.Sql;
using Microsoft.EntityFrameworkCore;
using NPaperless.DA.Interfaces;
using RabbitMQ.Client;
using Minio;
using Minio.Exceptions;
using Minio.DataModel.Args;
using Microsoft.Extensions.Options;

namespace NPaperless.API
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// The application configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
			 services
				.AddCors(options =>
				{
					options.AddPolicy(name: "CORS",
									policy  =>
									{
										policy
											.WithOrigins("http://localhost:*")
											.AllowAnyHeader();
									});
				});

			services
				.AddAutoMapper(typeof(AutoMapperProfile));

			services.AddScoped<IConfigApiLogic, ConfigApiLogic>();
			services.AddScoped<ICorrespondentLogic, CorrespondentLogic>();
			services.AddScoped<IDocTagLogic, DocTagLogic>();
			services.AddScoped<IDocumentLogic, DocumentLogic>();
			services.AddScoped<IDocumentTypeLogic, DocumentTypeLogic>();
			services.AddScoped<ILoginApiLogic, LoginApiLogic>();
			services.AddScoped<IUserInfoLogic, UserInfoLogic>();

			services.AddScoped<IValidator<Correspondent>, CorrespondentValidator>();
			services.AddScoped<IValidator<DocTag>, DocTagValidator>();
			services.AddScoped<IValidator<Document>, DocumentValidator>();
			services.AddScoped<IValidator<DocumentType>, DocumentTypeValidator>();
			services.AddScoped<IValidator<UserInfo>, UserInfoValidator>();

			services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IDocTagRepository, DocTagRepository>();
            services.AddScoped<ICorrespondentRepository, CorrespondentRepository>();

			services.AddDbContext<NPaperlessDbContext>(options =>
                options.UseNpgsql(Configuration.GetValue<string>("ConnectionString")));
			
			services.AddSingleton<IRabbitMQService, RabbitMQService>();

			services.AddSingleton<IMinioClient>(
                new MinioClient()
					.WithEndpoint("swkom-minio", 9000)
					.WithCredentials("swkom-minio", "swkom-minio")
					.WithSSL(false)
					.Build()
			);

            // Add framework services.
            services
                // Don't need the full MVC stack for an API, see https://andrewlock.net/comparing-startup-between-the-asp-net-core-3-templates/
                .AddControllers(options => {
                    options.InputFormatters.Insert(0, new InputFormatterStream());
                })
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    });
                });
            services
                .AddSwaggerGen(c =>
                {
                    c.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
                    
                    c.SwaggerDoc("1.0", new OpenApiInfo
                    {
                        Title = "PaperLess API",
                        Description = "PaperLess API (ASP.NET Core 6.0)",
                        TermsOfService = new Uri("https://github.com/openapitools/openapi-generator"),
                        Contact = new OpenApiContact
                        {
                            Name = "OpenAPI-Generator Contributors",
                            Url = new Uri("https://github.com/openapitools/openapi-generator"),
                            Email = ""
                        },
                        License = new OpenApiLicense
                        {
                            Name = "NoLicense",
                            Url = new Uri("http://localhost")
                        },
                        Version = "1.0",
                    });
                    c.CustomSchemaIds(type => type.FriendlyId(true));
                    c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{Assembly.GetEntryAssembly().GetName().Name}.xml");

                    // Include DataAnnotation attributes on Controller Action parameters as OpenAPI validation rules (e.g required, pattern, ..)
                    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
                    c.OperationFilter<GeneratePathParamsValidationFilter>();
                });
                services
                    .AddSwaggerGenNewtonsoftSupport();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
			app.UseCors("CORS");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSwagger(c =>
                {
                    c.RouteTemplate = "openapi/{documentName}/openapi.json";
                })
                .UseSwaggerUI(c =>
                {
                    // set route prefix to openapi, e.g. http://localhost:8080/openapi/index.html
                    c.RoutePrefix = "openapi";
                    //TODO: Either use the SwaggerGen generated OpenAPI contract (generated from C# classes)
                    c.SwaggerEndpoint("/openapi/1.0/openapi.json", "Mock Server");

                    //TODO: Or alternatively use the original OpenAPI contract that's included in the static files
                    // c.SwaggerEndpoint("/openapi-original.json", "Mock Server Original");
                });
            app.UseRouting();
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
