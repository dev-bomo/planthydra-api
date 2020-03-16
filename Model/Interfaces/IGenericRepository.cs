using System.Collections.Generic;
using System.Threading.Tasks;

namespace planthydra_api.Model.Interfaces
{
    public interface IGenericRepository<TInterface> where TInterface : class
    {
        Task<IEnumerable<TInterface>> GetAll();
        Task<TInterface> GetById(object id);
        void Insert(TInterface obj);
        void Update(TInterface obj);
        void Delete(object id);
    }
}