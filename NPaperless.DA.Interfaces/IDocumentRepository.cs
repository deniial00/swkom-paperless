using NPaperless.DA.Entities;
using System;
using System.Linq;

namespace NPaperless.DA.Interfaces
{
    public interface IDocumentRepository
    {
        public Document GetById(int id);

        public IQueryable<Document> GetAll();

        public void Add(Document document);

        public void Update(Document document);

        public void Delete(int id);
    }
}
