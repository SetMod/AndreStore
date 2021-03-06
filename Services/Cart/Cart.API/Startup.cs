using Cart.API.ConnectionFactory;
using Cart.API.GrpcServices;
using Cart.API.Interfaces.IConnectionFacory;
using Cart.API.Interfaces.IRpositories;
using Cart.API.Interfaces.IServices;
using Cart.API.Interfaces.IUnitOfWork;
using Cart.API.Mapper;
using Cart.API.Repositories;
using Cart.API.Services;
using Cart.API.UnitOfWork;
using Discount.GrpcService.Protos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System;
using MassTransit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API
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
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICartItemsRepository, CartItemsRepository>();
            #endregion

            #region Services
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ICartItemsService, CartItemsService>();
            #endregion

            services.AddTransient<IUnitOfWork, CartUnitOfWork>();

            #region Connection
            services.AddTransient<ICartConnectionFactory, CartConnectionFactory>();
            #endregion

            #region Automapper
            services.AddAutoMapper(typeof(MappingProfile));
            #endregion

            #region Grpc Configuration
            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
                        (o => o.Address = new Uri(Configuration["GrpcSettings:DiscountUrl"]));
            services.AddScoped<DiscountGrpcService>();
            #endregion

            #region Redis
            services.AddSingleton<IConnectionMultiplexer>(x =>
            {
                return ConnectionMultiplexer.Connect(Configuration.GetValue<string>("RedisConnection"));
            });
            services.AddTransient<IRedisCacheService, RedisCacheService>();
            #endregion

            #region MassTransit-RabbitMQ
            services.AddMassTransit(config => {
                config.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host(Configuration["EventBusSettings:HostAddress"]);
                });
            });
            services.AddMassTransitHostedService();
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cart.API", Version = "v1" });
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
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cart.API v1"));
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
