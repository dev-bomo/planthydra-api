using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using planthydra_api.DataAccess.Entities;
using planthydra_api.Model.Interfaces;
using planthydra_api.Model.Models;

namespace planthydra_api.Model.Repositories
{
    class DeviceRepository : BaseRepository<DeviceEntity>, IDeviceRepository
    {

        public DeviceRepository(Db context) : base(context)
        {

        }

        public async Task<IEnumerable<IDevice>> GetAll()
        {
            IEnumerable<DeviceEntity> des = await this.genericRepository.GetAll();
            IEnumerable<IDevice> devices = des.Select<DeviceEntity, IDevice>(de => new Device(de.Id, de.Name));
            return devices;
        }

        public async Task<IDevice> GetById(object id)
        {
            DeviceEntity de = await this.genericRepository.GetById(id);
            Device dev = new Device(de.Id, de.Name);
            return dev;
        }

        public void Insert(IDevice obj)
        {
            DeviceEntity de = new DeviceEntity();
            de.Name = obj.Name;
            de.Status = (int)obj.Status;

            this.genericRepository.Insert(de);
        }

        public async void Update(IDevice obj)
        {
            DeviceEntity de = await this.genericRepository.GetById(obj.Id);
            if (de == null) throw new ArgumentException("Device not in database, nothing to update");

            this.genericRepository.Update(de);
        }
    }
}