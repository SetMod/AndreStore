using Customer.API.CustomerUnitOfWork;
using Customer.API.EfDbContext;
using Customer.API.Interfaces;
using Customer.API.Interfaces.IRepositories;
using Customer.API.Interfaces.IServices;
using Customer.API.Repositories;
using Customer.API.Services;
using Customer.API.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Customer.API
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
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            #endregion

            #region Services
            services.AddTransient<ICustomerService, CustomerService>();
            #endregion

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<CustomerDbContext>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer.API", Version = "v1" });
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
