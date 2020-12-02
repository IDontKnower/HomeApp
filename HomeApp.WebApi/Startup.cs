using AutoMapper;
using HomeApp.WebApi.Contracts;
using HomeApp.WebApi.Mappers;
using HomeApp.WebApi.Services;
using HomeApp.WebApi.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestSharp;
using RestSharp.Serializers.SystemTextJson;

namespace HomeApp.WebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HomeApp.WebApi", Version = "v1" });
            });
            RegisterSettings(services);
            RegisterJwtAuth(services);
            RegisterMapperProfiles(services);
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeApp.WebApi v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterSettings(IServiceCollection services)
        {
            services.AddSingleton(Configuration.GetSection(nameof(AuthSettings)).Get<AuthSettings>());
            services.AddSingleton(Configuration.GetSection(nameof(WeatherSettings)).Get<WeatherSettings>());
            services.AddSingleton(Configuration.GetSection(nameof(DbSettings)).Get<DbSettings>());
        }

        private void RegisterJwtAuth(IServiceCollection services)
        {
            var config = Configuration.GetSection(nameof(AuthSettings)).Get<AuthSettings>();

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.Authority = config.Authority;
                cfg.Audience = config.Audience;
                cfg.IncludeErrorDetails = true;
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidIssuer = config.Authority,
                    ValidateLifetime = true
                };

                cfg.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        c.Response.StatusCode = 401;
                        c.Response.ContentType = "text/plain";
                        return c.Response.WriteAsync(c.Exception.ToString());
                    }
                };
            });
        }

        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IWeatherService, OpenWeatherService>();

            services.AddTransient<IRestClient, RestClient>(ctx =>
            {
                var restClient = new RestClient();
                restClient.UseSystemTextJson();
                return restClient;
            });
        }

        private void RegisterMapperProfiles(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(WeatherProfile));
        }
    }
}
