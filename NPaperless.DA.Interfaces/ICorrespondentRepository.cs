using NPaperless.DA.Entities;
using System;
using System.Linq;

namespace NPaperless.DA.Interfaces
{
    public interface ICorrespondentRepository
    {
        public Correspondent GetById(long id);

        public IQueryable<Correspondent> GetAll();

        public void Add(Correspondent correspondent);

        public void Update(Correspondent correspondent);

        public void Delete(long id);
    }
}
