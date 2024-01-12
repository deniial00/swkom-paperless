using NPaperless.DA.Entities;
using System;
using System.Linq;

namespace NPaperless.DA.Interfaces
{
    public interface IDocTagRepository
    {
        public DocTag GetById(long id);

        public IQueryable<DocTag> GetAll();

        public void Add(DocTag docTag);

        public void Update(DocTag docTag);
        public void Delete(long id);
    }
}
