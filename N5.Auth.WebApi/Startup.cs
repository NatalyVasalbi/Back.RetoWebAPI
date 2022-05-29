using Autofac;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using N5.Authentication.Backend.Application.Behaviours;
using N5.Authentication.Backend.Application.Configuration;
using N5.Authentication.Backend.Application.Contracts.Persistence;
using N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.CreatePermissionsCommand;
using N5.Authentication.Backend.Application.Features.Commands.PermissionCommands.UpdatePermissionsCommand;
using N5.Authentication.Backend.Application.Mappings;
using N5.Authentication.Backend.Infrastructure.Persistance;
using N5.Authentication.Backend.Infrastructure.Repositories;
using System.Reflection;


namespace N5.Auth.WebApi
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
            services.AddControllers()
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<CreatePermissionsCommandValidator>())
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<UpdatePermissionsCommandValidator>());
            services.AddAutoMapper(typeof(MappingProfile));          
            services.AddMediatR(Assembly.GetExecutingAssembly());
              
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddDbContext<PermissionDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IPermissionsRepository, PermissionsRepository>();
            services.AddScoped<IPermissionTypesRepository, PermissionTypesRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "N5.Auth.WebApi", Version = "v1" });
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsRule", rule =>
                {
                    rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
                });
            });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new MediatorModule());
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "N5.Auth.WebApi v1"));
            }

            app.UseRouting();
            app.UseCors("CorsRule");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
