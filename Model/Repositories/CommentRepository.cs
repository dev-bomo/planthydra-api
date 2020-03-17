using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using planthydra_api.DataAccess.Entities;
using planthydra_api.Model.Interfaces;
using planthydra_api.Model.Models;

namespace planthydra_api.Model.Repositories
{
    class CommentRepository : BaseRepository<CommentEntity>, ICommentRepository
    {
        public CommentRepository(Db context) : base(context)
        {

        }

        public async Task<IEnumerable<IComment>> GetAll()
        {
            IEnumerable<CommentEntity> ces = await this.genericRepository.GetAll();
            IEnumerable<IComment> comments = ces.Select<CommentEntity, IComment>(ce => new Comment(ce.Id, ce.Sinopsis, ce.DescriptionHtml, ce.PlantId));

            return comments;
        }

        public async Task<IComment> GetById(object id)
        {
            CommentEntity ce = await this.genericRepository.GetById(id);
            Comment comment = new Comment(ce.Id, ce.Sinopsis, ce.DescriptionHtml, ce.PlantId);

            return comment;
        }

        public void Insert(IComment obj)
        {
            CommentEntity ce = new CommentEntity();
            ce.DescriptionHtml = obj.DescriptionHtml;
            ce.PlantId = obj.PlantId;
            ce.Sinopsis = obj.Sinopsis;

            this.genericRepository.Insert(ce);
        }

        public async void Update(IComment obj)
        {
            CommentEntity ce = await this.genericRepository.GetById(obj.Id);
            if (ce == null) throw new ArgumentException("Comment not in database, nothing to update");

            this.genericRepository.Update(ce);
        }
    }
}