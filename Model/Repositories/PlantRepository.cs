using System.Collections.Generic;
using System.Threading.Tasks;
using planthydra_api.DataAccess.Entities;
using planthydra_api.Model.Interfaces;

namespace planthydra_api.Model.Repositories
{
    class PlantRepository : BaseRepository<PlantEntity>, IPlantRepository
    {
        public PlantRepository(Db context) : base(context)
        {

        }

        public Task<IEnumerable<IPlant>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<IPlant> GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(IPlant obj)
        {
            throw new System.NotImplementedException();
        }

        public void Update(IPlant obj)
        {
            throw new System.NotImplementedException();
        }
    }
}