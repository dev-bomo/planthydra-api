using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace planthydra_api.Model
{
    public static class EnvironmentExtensions
    {
        private static string SqlConnectionStringKey = "SqliteConnectionString";
        public static string GetSqlConnectionString(this IHostEnvironment webHostEnvironment)
        {
            string? connString = Environment.GetEnvironmentVariable(SqlConnectionStringKey);
            if (String.IsNullOrEmpty(connString))
            {
                throw new Exception("Could not find env variable " + SqlConnectionStringKey);
            }
            else
            {
                return connString;
            }
        }
    }
}