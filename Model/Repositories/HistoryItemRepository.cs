using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using planthydra_api.DataAccess.Entities;
using planthydra_api.Model.Interfaces;
using planthydra_api.Model.Models;

namespace planthydra_api.Model.Repositories
{
    class HistoryItemRepository : BaseRepository<HistoryEntity>, IHistoryItemRepository
    {
        public HistoryItemRepository(Db context) : base(context)
        {

        }

        public async Task<IEnumerable<IHistoryItem>> GetAll()
        {
            IEnumerable<HistoryEntity> he = await this.genericRepository.GetAll();
            IEnumerable<IHistoryItem> schedules = he.Select<HistoryEntity, IHistoryItem>(se => new HistoryItem(se.Id, se.Duration, se.StartTime, se.DeviceId, se.ScheduleId));

            return schedules;
        }

        public async Task<IHistoryItem> GetById(object id)
        {
            HistoryEntity he = await this.genericRepository.GetById(id);
            HistoryItem history = new HistoryItem(he.Id, he.Duration, he.StartTime, he.DeviceId, he.ScheduleId);

            return history;
        }

        public void Insert(IHistoryItem obj)
        {
            HistoryEntity he = new HistoryEntity();
            he.DeviceId = obj.DeviceId;
            he.Duration = obj.Duration;
            he.ScheduleId = obj.ScheduleId;
            he.StartTime = obj.StartTime;

            this.genericRepository.Insert(he);
        }

        public async void Update(IHistoryItem obj)
        {
            HistoryEntity he = await this.genericRepository.GetById(obj.Id);
            if (he == null) throw new ArgumentException("Image not in db. Nothing to update");

            this.genericRepository.Update(he);
        }
    }
}