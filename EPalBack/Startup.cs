using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPalBack.Helpers;
using EPalBack.DataModels;
using Microsoft.EntityFrameworkCore;
using EPalBack.Repositories;
using EPalBack.Services;

namespace EPalBack
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
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EPalBack", Version = "v1" });
            //});


            //註冊 Swagger 服務
            services.AddSwaggerDocument(config => {

                var apiScheme = new OpenApiSecurityScheme()
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "請將Token填入: Bearer {Token}"

                };
                config.AddSecurity("JWT Token", Enumerable.Empty<string>(), apiScheme);
                config.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT Token"));
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(option =>
                    {
                        option.IncludeErrorDetails = true;
                        option.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateLifetime = true,
                            ValidIssuer = JwtHelper.Issuer,
                            IssuerSigningKey = JwtHelper.SecurityKey,
                            ValidateAudience = false
                        };

                    });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                       builder =>
                       {
                          builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                       });
            });
            services.AddControllers();

            //dbcontext.repository.service DI註冊
            services.AddDbContext<EPalContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("EPalContext")));
            services.AddScoped<Repository<Product>>();
            services.AddScoped<Repository<Member>>();
            services.AddScoped<Repository<CommentDetail>>();
            services.AddScoped<Repository<Order>>();
            services.AddScoped<ProductService>();
            services.AddScoped<MemberService>();
            services.AddScoped<DashBoardService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EPalBack v1"));
            }


            app.UseHttpsRedirection();

            //安裝nswagger
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors();

            //先驗證
            app.UseAuthentication();
            //再授權
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
