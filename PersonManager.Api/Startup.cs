using AutoMapper;
using DeliverySystem.Infrastructure;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonManager.Api.Commands;
using PersonManager.Api.CommandValidators;
using PersonManager.Api.Mapping;
using PersonManager.Api.Queries;
using PersonManager.Domain.Persons;
using PersonManager.Infrastructure;
using PersonManager.Infrastructure.Repositories;
using PersonManager.Tools.Middleware;

namespace PersonManager.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddFluentValidation();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .WithOrigins("http://localhost:4200", "http://localhost:8080")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });

            ConfigureAutoMapper(services);
            ConfigureQueries(services);
            ConfigureValidators(services);
            ConfigureRepositories(services);
            services.AddMediatR();
            ConfigureDbContext(services);
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

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GroupMapping());
                mc.AddProfile(new PersonMapping());
            });

            services.AddSingleton(mappingConfig.CreateMapper());
        }

        private void ConfigureQueries(IServiceCollection services)
        {
            services.AddScoped<IGroupQueries, GroupQueries>();
            services.AddScoped<IPersonQueries, PersonQueries>();
        }

        private void ConfigureValidators(IServiceCollection services)
        {
            services.AddScoped<IValidator<AddPersonCommand>, AddPersonCommandValidator>();
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGroupRepository, PersonManagerRepository>();
        }

        private void ConfigureDbContext(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(option =>
            {
                option = new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlServer(Configuration.GetConnectionString("AppEntities"));
            });
        }
    }
}
