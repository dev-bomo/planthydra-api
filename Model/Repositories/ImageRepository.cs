using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using planthydra_api.DataAccess.Entities;
using planthydra_api.Model.Interfaces;
using planthydra_api.Model.Models;

namespace planthydra_api.Model.Repositories
{
    class ImageRepository : BaseRepository<ImageEntity>, IImageRepository
    {
        public ImageRepository(Db context) : base(context)
        {

        }

        public async Task<IEnumerable<IImage>> GetAll()
        {
            IEnumerable<ImageEntity> ies = await this.genericRepository.GetAll();
            IEnumerable<IImage> images = ies.Select<ImageEntity, IImage>(se => new Image(se.Id, se.FileName, se.Url));

            return images;
        }

        public async Task<IImage> GetById(object id)
        {
            ImageEntity ie = await this.genericRepository.GetById(id);
            Image sch = new Image(ie.Id, ie.FileName, ie.Url);

            return sch;
        }

        public void Insert(IImage obj)
        {
            ImageEntity ie = new ImageEntity();
            ie.Url = obj.Url;
            ie.FileName = obj.FileName;

            this.genericRepository.Insert(ie);
        }

        public async void Update(IImage obj)
        {
            ImageEntity ie = await this.genericRepository.GetById(obj.Id);
            if (ie == null) throw new ArgumentException("Image not in db. Nothing to update");

            this.genericRepository.Update(ie);
        }
    }
}