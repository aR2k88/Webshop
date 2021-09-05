using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Webshop.DataProviders;
using Webshop.Infrastructure;
using Webshop.Interfaces;
using Webshop.Services;

namespace Webshop
{
    public class Startup
    {
        public IConfiguration Configuration;
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            Log.Information("Application starting...");
            var settings = Configuration.Get<Settings>();
            settings.EnvironmentString =
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLowerInvariant() ?? "development";
            services.AddSingleton(settings);

            services.AddSingleton(MongoDbConnection.ConnectToMongoDb(settings.MongoDatabase.ConnectionString,
                settings.MongoDatabase.DatabaseName));
            services.AddSingleton<IProductDataProvider, ProductDataProvider>();
            services.AddSingleton<ICategoryDataProvider, CategoryDataProvider>();
            services.AddSingleton<IProductUrlDataProvider, ProductUrlDataProvider>();
            services.AddSingleton<ICartDataProvider, CartDataProvider>();
            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IUrlManagerService, UrlManagerService>();
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost",
                            "http://localhost:8080",
                            "https://webshop.dev.rutefjord.no");
                        builder.AllowAnyHeader();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            // });
        }
    }
}