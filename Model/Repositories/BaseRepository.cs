using planthydra_api.DataAccess.Entities;

namespace planthydra_api.Model.Repositories
{
    class BaseRepository<TInterface> where TInterface : class
    {
        protected Db context;
        protected GenericRepository<TInterface> genericRepository;

        public BaseRepository(Db context)
        {
            this.context = context;
            this.genericRepository = new GenericRepository<TInterface>(context);
        }
    }
}