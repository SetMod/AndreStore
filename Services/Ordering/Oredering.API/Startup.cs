using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Ordering.API.Mapper;
using Ordering.BLL.Interfaces.IServices;
using Ordering.BLL.Interfaces.IUnitOfWork;
using Ordering.BLL.Services;
using Ordering.BLL.UnitOfWork;
using Ordering.DAL.Interfaces.IRepositories;
using Ordering.DAL.Repositories;
using Oredering.DAL.OrderigDbContext;

namespace Oredering.API
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
            services.AddControllers();

            #region Repositories
            services.AddTransient<IOrderingRepository, OrderingRepository>();
            #endregion

            #region Services
            services.AddTransient<IOrderingService, OrderingService>();
            #endregion

            #region EntityFramework
            services.AddDbContext<OrderingDbContext>();
            #endregion

            #region Automapper
            services.AddAutoMapper(typeof(MappingProfile));
            #endregion

            #region UnitOfWork
            services.AddTransient<IOrderingUnitOfWork, OrderingUnitOfWork>();
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ordering.API", Version = "v1" });
            });
            #endregion

            #region IdentityServer
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = "Ordering.API";
                    options.Authority = "https://localhost:6001";
                });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ordering.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
