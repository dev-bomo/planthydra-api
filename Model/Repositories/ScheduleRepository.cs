using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using planthydra_api.DataAccess.Entities;
using planthydra_api.Model.Interfaces;
using planthydra_api.Model.Models;

namespace planthydra_api.Model.Repositories
{
    class ScheduleRepository : BaseRepository<ScheduleEntity>, IScheduleRepository
    {
        public ScheduleRepository(Db context) : base(context)
        {

        }

        public async Task<IEnumerable<ISchedule>> GetAll()
        {
            IEnumerable<ScheduleEntity> ses = await this.genericRepository.GetAll();
            IEnumerable<ISchedule> schedules = ses.Select(se => new Schedule(se.Id, se.Duration, se.IsEnabled, se.StartTime, se.DeviceId, se.Weekdays));

            return schedules;
        }

        public async Task<ISchedule> GetById(object id)
        {
            ScheduleEntity se = await this.genericRepository.GetById(id);
            Schedule sch = new Schedule(se.Id, se.Duration, se.IsEnabled, se.StartTime, se.DeviceId, se.Weekdays);

            return sch;
        }

        /// <summary>
        /// This won't add the dependent IDevice if it's not already in the DB
        /// </summary>
        /// <param name="obj"></param>
        public void Insert(ISchedule obj)
        {
            ScheduleEntity se = new ScheduleEntity();
            se.Duration = obj.Duration;
            se.IsEnabled = obj.IsEnabled;
            se.Name = obj.Name;
            se.Weekdays = obj.Weekdays;
            se.DeviceId = obj.DeviceId;

            this.genericRepository.Insert(se);
        }

        public async void Update(ISchedule obj)
        {
            ScheduleEntity se = await this.genericRepository.GetById(obj.Id);
            if (se == null) throw new ArgumentException("ScheduleItem not in db. Nothing to update");

            this.genericRepository.Update(se);
        }
    }
}