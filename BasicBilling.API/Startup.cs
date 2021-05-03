using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicBilling.API.Interface;
using BasicBilling.API.Models;
using BasicBilling.API.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BasicBilling.API
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
            services.AddCors();
            services.AddMvc();

            services.AddEntityFrameworkSqlite()
            .AddDbContext<BasicBillingDBContext>();

            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IBillStatusRepository, BillStatusRepository>();

            services.AddControllers()
                .AddJsonOptions(options =>
               options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BasicBilling.API", Version = "v1" });
            });
            //services.addjson
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BasicBilling.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
