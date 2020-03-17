using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using planthydra_api.DataAccess.Entities;
using planthydra_api.Model.Interfaces;

namespace planthydra_api.Model.Repositories
{
    public class Repo : IDisposable
    {
        private Db _context;
        public IUserRepository User { get; private set; }
        public IDeviceRepository Device { get; private set; }
        public ISensorDataRepository SensorData
        {
            get; private set;
        }
        public Repo(IConfiguration configuration)
        {
            DbContextOptionsBuilder<Db> db = new DbContextOptionsBuilder<Db>();
            db.UseSqlite(configuration["SqliteConnectionString"]);
            _context = new Db(db.Options);

            this.User = new UserRepository(_context);
            this.Device = new DeviceRepository(_context);
            this.SensorData = new SensorDataRepository(_context);
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