using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Webshop.DataProviders;
using Webshop.Infrastructure;
using Webshop.Interfaces;
using Webshop.Middleware;
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
            services.AddSingleton<UserDataProvider>();
            services.AddSingleton<JwtSecurityTokenHandler>();
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost",
                            "http://localhost:8080",
                            "http://localhost:8082",
                            "https://webshop.dev.rutefjord.no");
                        builder.AllowAnyHeader();
                    });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = settings.JwtConfig.Issuer,
                        ValidAudience = settings.JwtConfig.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtConfig.Secret))
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            if (!env.IsDevelopment())
            {
                app.UseDefaultFiles();
                app.UseStaticFiles();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseRouting();
            
            //
            // app.UseWhen(context => context.Request.Path.StartsWithSegments("/api/admin"), appBuilder =>
            // {
            //     appBuilder.UseMiddleware<JwtTokenMiddleware>();
            // });
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.Use(async (context, next) =>
            {
                if (context?.Request != null && context.Request.Path.StartsWithSegments(new PathString("/api")) != true)
                {
                    context.Request.Path = "/index.html";
                    Console.WriteLine("Her er vi");
                }
                await next();
            });
            app.UseStaticFiles();
        }
    }
}