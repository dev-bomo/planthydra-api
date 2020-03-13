using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace planthydra_api.DataAccess.Entities
{
#pragma warning disable CS8618
    internal class Db : IdentityDbContext<UserEntity>
    {
        public DbSet<UserEntity> IdentityUsers { get; set; }
        public DbSet<AppUserEntity> AppUsers { get; set; }
        public DbSet<DeviceEntity> Devices { get; set; }

        public DbSet<ImageEntity> Images { get; set; }

        public DbSet<PlantEntity> Plants { get; set; }

        public DbSet<HistoryEntity> HistoryItems { get; set; }

        public DbSet<CommentEntity> PlantComments { get; set; }

        public DbSet<ScheduleEntity> ScheduleItems { get; set; }

        public DbSet<SensorDataEntity> SensorDataItems { get; set; }

        public Db(DbContextOptions<Db> options) : base(options)
        {

        }
    }
}