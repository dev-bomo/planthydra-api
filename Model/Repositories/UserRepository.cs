using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using planthydra_api.DataAccess.Entities;
using planthydra_api.Model.Interfaces;
using planthydra_api.Model.Models;

namespace planthydra_api.Model.Repositories
{
    class UserRepository : IUserRepository
    {
        private Db _context;
        private GenericRepository<AppUserEntity> _genericRepository;

        public UserRepository(Db context)
        {
            this._genericRepository = new GenericRepository<AppUserEntity>(context);
            this._context = context;
        }

        public async Task<IEnumerable<IUser>> GetAll()
        {
            IEnumerable<AppUserEntity> usrs = await this._genericRepository.GetAll();
            IEnumerable<IUser> users =
                usrs.Select<AppUserEntity, IUser>(ue => new User(ue.User, ue.Name, ue.Email));

            return users;
        }

        public void Insert(IUser obj)
        {
            AppUserEntity ue = new AppUserEntity(obj.IdentityUser);
            ue.Name = obj.Name;
            ue.Email = obj.Email;

            this._genericRepository.Insert(ue);
        }

        public async void Update(IUser obj)
        {
            AppUserEntity ue = await this._genericRepository.GetById(obj.Id);
            if (ue == null) throw new ArgumentException("User not in database, nothing to update");

            this._genericRepository.Update(ue);
        }

        public async Task<IUser> GetById(object id)
        {
            AppUserEntity ue = await this._genericRepository.GetById(id);
            User usr = new User(ue.User, ue.Name, ue.Email);

            return usr;
        }

        public void Delete(object id)
        {
            this._genericRepository.Delete(id);
        }

        public void Save()
        {
            this._genericRepository.Save();
        }
    }
}