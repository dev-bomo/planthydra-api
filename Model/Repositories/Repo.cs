using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using planthydra_api.DataAccess.Entities;
using planthydra_api.Model.Interfaces;

namespace planthydra_api.Model.Repositories
{
    class Repo : IRepo, IDisposable
    {
        private Db _context;
        public IUserRepository User { get; private set; }
        public IDeviceRepository Device { get; private set; }
        public ISensorDataRepository SensorData { get; private set; }
        public IScheduleRepository Schedule { get; private set; }
        public ICommentRepository Comment { get; private set; }
        public IImageRepository Image { get; private set; }

        // This should probably be part of some identity subrepo
        public IUserRoleRepository UserRole { get; private set; }

        public Repo(Db context)
        {
            _context = context;

            this.User = new UserRepository(_context);
            this.Device = new DeviceRepository(_context);
            this.SensorData = new SensorDataRepository(_context);
            this.Schedule = new ScheduleRepository(_context);
            this.Comment = new CommentRepository(_context);
            this.Image = new ImageRepository(_context);
            this.UserRole = new UserRoleRepository(_context);
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