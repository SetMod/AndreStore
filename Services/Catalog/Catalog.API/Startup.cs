using Catalog.API.Filters;
using Catalog.API.Mapper;
using Catalog.Application;
using Catalog.Application.Interfaces;
using Catalog.Application.Interfaces.IMongo;
using Catalog.Infrastructure.Repositories;
using Catalog.Infrastructure.RepUnitOfWork;
using Catalog.Infrastructure.Services;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Ordering.DAL.MongoDBSettings;

namespace Catalog.API
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
            services.AddControllers(options => {
                options.EnableEndpointRouting = true;
                options.Filters.Add<ValidationFilter>();
                })
                .AddFluentValidation(s =>
                {
                    s.RegisterValidatorsFromAssemblyContaining<Startup>();
                    s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });

            #region  Repositories
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IDeliveryRepository, DeliveryRepository>();
            #endregion

            #region  Services
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IDeliveryService, DeliveryService>();
            #endregion

            #region MongoDB
            services.Configure<MongoDBSettings>(Configuration.GetSection(nameof(MongoDBSettings)));
            services.AddSingleton<IMongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);
            #endregion

            #region Automapper
            services.AddAutoMapper(typeof(MappingProfile));
            #endregion

            #region MediatR + Automapper
            services.AddApplicationServices();
            #endregion

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" });
            });
            #endregion

            //// MassTransit-RabbitMQ Configuration
            //services.AddMassTransit(config => {

            //    config.AddConsumer<BasketCheckoutConsumer>();

            //    config.UsingRabbitMq((ctx, cfg) => {
            //        cfg.Host(Configuration["EventBusSettings:HostAddress"]);
            //        cfg.UseHealthCheck(ctx);

            //        cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c => {
            //            c.ConfigureConsumer<BasketCheckoutConsumer>(ctx);
            //        });
            //    });
            //});
            //services.AddMassTransitHostedService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));
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
