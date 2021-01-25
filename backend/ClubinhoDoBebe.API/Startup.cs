using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using AutoMapper;
using ClubinhoDoBebe.Infra.Services;
using ClubinhoDoBebe.Infra.Services.Interfaces;
using ClubinhoDoBebe.Infra.Repository;
using ClubinhoDoBebe.Infra.Repository.Interfaces;

namespace ClubinhoDoBebe.API
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClubinhoDoBebe.API", Version = "v1" });
            });

            services.AddAutoMapper((config) =>
            {
                config.AllowNullCollections = true;
                config.AllowNullDestinationValues = true;
            });

            services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "https://securetoken.google.com/clubinhodobebe-cd995";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "https://securetoken.google.com/clubinhodobebe-cd995",
                    ValidateAudience = true,
                    ValidAudience = "clubinhodobebe-cd995",
                    ValidateLifetime = true
                };
            });

            services.AddSingleton<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClubinhoDoBebe.API v1"));
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
