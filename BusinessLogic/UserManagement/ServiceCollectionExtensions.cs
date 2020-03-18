using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using planthydra_api.DataAccess.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Microsoft.Extensions.Configuration;

namespace planthydra_api.BusinessLogic.UserManagement
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAuthServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(config =>
                 {
                     config.SignIn.RequireConfirmedEmail = false;
                     config.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultPhoneProvider;
                 })
                 .AddEntityFrameworkStores<Db>()
                 .AddRoles<IdentityRole>()
                 .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = config["JwtIssuer"],
                        ValidAudience = config["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                }).AddFacebook(facebookOptions => // are these really needed?
                {
                    facebookOptions.AppId = config["FbAppId"];
                    facebookOptions.AppSecret = config["FbSecret"];
                }); ;
        }
    }
}