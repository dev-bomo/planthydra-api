using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using planthydra_api.DataAccess.Models;

namespace planthydra_api.DataAccess.Db
{
#pragma warning disable CS8618
    class Db : IdentityDbContext<User>
    {
        public DbSet<User> AppUsers { get; set; }
        public DbSet<Device> Devices { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Plant> Plants { get; set; }

        public DbSet<HistoryItem> HistoryItems { get; set; }

        public DbSet<PlantComment> PlantComments { get; set; }

        public DbSet<ScheduleItem> ScheduleItems { get; set; }

        public DbSet<SensorData> SensorDataItems { get; set; }
    }
}