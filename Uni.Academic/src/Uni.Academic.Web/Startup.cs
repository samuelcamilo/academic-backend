using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Uni.Academic.Data;
using Uni.Academic.IoC;

namespace Uni.Academic.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly Container _container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            InitializeContainer();
            services.AddControllers();

            services.AddDbContext<AcademicContext>(options =>
            {
                var connectionString = Configuration[$"ConnectionStrings:DefaultConnection@{Environment.MachineName}"];
                connectionString ??= Configuration["ConnectionStrings:DefaultConnection"];

                options.UseSqlServer(connectionString);
            });

            services.AddSimpleInjector(_container, c => c.AddAspNetCore().AddControllerActivation());
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSimpleInjector(_container);
            _container.Verify();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            using (AsyncScopedLifestyle.BeginScope(_container))
            using (var ctx = _container.GetService<AcademicContext>())
                ctx.Database.Migrate();

            app.UseRouting();
            app.UseAuthorization();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "QAcademic BackEnd");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InitializeContainer()
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            SimpleInjectorBootstrap.Initialize(_container);
        }
    }
}
