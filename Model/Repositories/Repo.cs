using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using planthydra_api.DataAccess.Entities;
using planthydra_api.Model.Interfaces;

namespace planthydra_api.Model.Repositories
{
    public class Repo : IDisposable
    {
        private Db _context;
        public IUserRepository User { get; private set; }
        public IDeviceRepository Device { get; private set; }
        public ISensorDataRepository SensorData { get; private set; }
        public IScheduleRepository Schedule { get; private set; }
        public ICommentRepository Comment { get; private set; }
        public IImageRepository Image { get; private set; }
        public Repo(IConfiguration configuration)
        {
            DbContextOptionsBuilder<Db> db = new DbContextOptionsBuilder<Db>();
            db.UseSqlite(configuration["SqliteConnectionString"]);
            _context = new Db(db.Options);

            this.User = new UserRepository(_context);
            this.Device = new DeviceRepository(_context);
            this.SensorData = new SensorDataRepository(_context);
            this.Schedule = new ScheduleRepository(_context);
            this.Comment = new CommentRepository(_context);
            this.Image = new ImageRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}