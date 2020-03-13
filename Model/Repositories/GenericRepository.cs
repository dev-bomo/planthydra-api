using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using planthydra_api.DataAccess.Entities;
using planthydra_api.Model.Interfaces;

namespace planthydra_api.Model.Repositories
{
    class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private Db _context;
        private DbSet<T> _table;

        public GenericRepository(Db context)
        {
            this._context = context;
            this._table = _context.Set<T>();
        }

        public void Delete(object id)
        {
            T existing = _table.Find(id);
            this._table.Remove(existing);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this._table.ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await this._table.FindAsync();
        }

        public void Insert(T obj)
        {
            this._table.Add(obj);
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        public void Update(T obj)
        {
            this._table.Attach(obj);
            this._context.Entry(obj).State = EntityState.Modified;
        }
    }
}