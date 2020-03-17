using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using planthydra_api.DataAccess.Entities;
using planthydra_api.Model.Interfaces;
using planthydra_api.Model.Models;

namespace planthydra_api.Model.Repositories
{
    class SensorDataRepository : BaseRepository<SensorDataEntity>, ISensorDataRepository
    {
        public SensorDataRepository(Db context) : base(context)
        {

        }

        public async Task<IEnumerable<ISensorData>> GetAll()
        {
            IEnumerable<SensorDataEntity> sdes = await this.genericRepository.GetAll();
            IEnumerable<ISensorData> sensorData = sdes.Select<SensorDataEntity, ISensorData>(sde =>
            new SensorData(sde.Id, (SensorDataType)sde.Type, sde.Value, sde.Time));

            return sensorData;
        }

        public async Task<ISensorData> GetById(object id)
        {
            SensorDataEntity sde = await this.genericRepository.GetById(id);
            SensorData sd = new SensorData(sde.Id, (SensorDataType)sde.Type, sde.Value, sde.Time);

            return sd;
        }

        public void Insert(ISensorData obj)
        {
            SensorDataEntity sde = new SensorDataEntity();
            sde.Time = obj.Time;
            sde.Type = (int)obj.Type;
            sde.Value = obj.Value;

            this.genericRepository.Insert(sde);
        }

        public async void Update(ISensorData obj)
        {
            SensorDataEntity sde = await this.genericRepository.GetById(obj.Id);
            if (sde == null) throw new ArgumentException("SensorDataItem not in db, nothing to update");

            this.genericRepository.Update(sde);
        }
    }
}