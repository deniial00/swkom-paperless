using NPaperless.DA.Entities;
using System;
using System.Linq;

namespace NPaperless.DA.Interfaces
{
    public interface IDocumentTypeRepository
    {
		public DocumentType GetById(long id);

        public IQueryable<DocumentType> GetAll();

        public void Add(DocumentType documentType);

        public void Update(DocumentType documentType);

        public void Delete(long id);
    }
}
