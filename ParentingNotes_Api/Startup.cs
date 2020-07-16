using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ParentingNotes_Api.Common;
using ParentingNotes_Api.Services.Implements;
using ParentingNotes_Api.Services.Interfaces;
using System;
using System.Linq;
using System.Text;

namespace ParentingNotes_Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();//json字符串大小写原样输出
                });

            services.AddScoped<ITokenService, TokenService>();

            services.Configure<JwtSetting>(Configuration.GetSection("JwtSetting"));

            #region Jwt
            var jwtSetting = new JwtSetting();
            Configuration.Bind("JwtSetting", jwtSetting);
            //添加策略鉴权模式
            services.AddAuthorization()
               .AddAuthentication(x =>
               {
                   x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                   x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               })
               .AddJwtBearer(option =>
               {
                   option.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateLifetime = true,//是否验证失效时间
                       ClockSkew = TimeSpan.FromSeconds(30),

                       ValidateAudience = true,//是否验证Audience
                                               //ValidAudience = Const.GetValidudience(),//Audience
                                               //这里采用动态验证的方式，在重新登陆时，刷新token，旧token就强制失效了
                       AudienceValidator = (m, n, z) =>
                       {
                           return m != null && m.FirstOrDefault().Equals(jwtSetting.Audience);
                       },
                       ValidateIssuer = true,//是否验证Issuer
                       ValidIssuer = jwtSetting.Issuer,//Issuer，这两项和前面签发jwt的设置一致

                       ValidateIssuerSigningKey = true,//是否验证SecurityKey
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.SecurityKey))//拿到SecurityKey
                   };
               });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
