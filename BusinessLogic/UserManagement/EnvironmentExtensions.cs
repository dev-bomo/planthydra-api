using System;
using Microsoft.Extensions.Hosting;

namespace planthydra_api.BusinessLogic.UserManagement
{
    static class EnvironmentExtensions
    {
        private static string JwtIssuerKey = "JwtIssuer";
        private static string JwtKeyKey = "JwtKey";
        private static string FbAppIdKey = "FbAppId";
        private static string FbSecretKey = "FbSecret";
        public static string GetJwtIssuer(this IHostEnvironment webHostEnvironment)
        {
            string? jwtIssuer = Environment.GetEnvironmentVariable(JwtIssuerKey);
            if (string.IsNullOrEmpty(jwtIssuer))
            {
                throw new Exception("Could not find env variable " + JwtIssuerKey);
            }
            else
            {
                return jwtIssuer;
            }
        }

        public static string GetJwtKey(this IHostEnvironment webHostEnvironment)
        {
            string? jwtKey = Environment.GetEnvironmentVariable(JwtKeyKey);
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new Exception("Could not find env variable " + JwtKeyKey);
            }
            else
            {
                return jwtKey;
            }
        }

        public static string GetFbAppId(this IHostEnvironment webHostEnvironment)
        {
            string? fbAppId = Environment.GetEnvironmentVariable(FbAppIdKey);
            if (string.IsNullOrEmpty(fbAppId))
            {
                throw new Exception("Could not find env variable " + FbAppIdKey);
            }
            else
            {
                return fbAppId;
            }
        }

        public static string GetFbSecret(this IHostEnvironment webHostEnvironment)
        {
            string? fbSecret = Environment.GetEnvironmentVariable(FbSecretKey);
            if (string.IsNullOrEmpty(fbSecret))
            {
                throw new Exception("Could not find env variable " + FbSecretKey);
            }
            else
            {
                return fbSecret;
            }
        }
    }
}