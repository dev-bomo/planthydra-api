using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace planthydra_api.DataAccess.Entities
{
#pragma warning disable CS8618 // these are EF specific and are not visible outside the package
    class Db : IdentityDbContext<IdentityUser>
    {
        public DbSet<IdentityUser> IdentityUsers { get; set; }
        public DbSet<AppUserEntity> AppUsers { get; set; }
        public DbSet<DeviceEntity> Devices { get; set; }

        public DbSet<ImageEntity> Images { get; set; }

        public DbSet<PlantEntity> Plants { get; set; }

        public DbSet<HistoryEntity> HistoryItems { get; set; }

        public DbSet<CommentEntity> PlantComments { get; set; }

        public DbSet<ScheduleEntity> ScheduleItems { get; set; }

        public DbSet<SensorDataEntity> SensorDataItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DevicePlantEntity>()
                .HasKey(bc => new { bc.DeviceId, bc.PlantId });
            modelBuilder.Entity<DevicePlantEntity>()
                .HasOne(dp => dp.Device)
                .WithMany(d => d.DevicePlantRelations)
                .HasForeignKey(dp => dp.DeviceId);
            modelBuilder.Entity<DevicePlantEntity>()
                .HasOne(dp => dp.Plant)
                .WithMany(p => p.DevicePlantRelations)
                .HasForeignKey(dp => dp.PlantId);
            base.OnModelCreating(modelBuilder);
        }

        public Db(DbContextOptions<Db> options) : base(options)
        {

        }
    }
}