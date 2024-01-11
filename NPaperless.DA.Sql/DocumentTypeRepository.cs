using NPaperless.DA.Entities;
using NPaperless.DA.Interfaces;
using System;
using System.Linq;

namespace NPaperless.DA.Sql
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly NPaperlessDbContext _dbContext;

        public DocumentTypeRepository(NPaperlessDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new DAException(nameof(dbContext));
        }

        public DocumentType GetById(long id)
        {
            return _dbContext.DocumentTypes.Find(id);
        }

        public IQueryable<DocumentType> GetAll()
        {
            return _dbContext.DocumentTypes;
        }

        public void Add(DocumentType documentType)
        {
            _dbContext.DocumentTypes.Add(documentType);
            _dbContext.SaveChanges();
        }

        public void Update(DocumentType documentType)
        {
            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var documentType = _dbContext.DocumentTypes.Find(id);
            if (documentType != null)
            {
                _dbContext.DocumentTypes.Remove(documentType);
                _dbContext.SaveChanges();
            }
			else{
				throw new DAException("Error: No DocuemntType with the id " + id + " was found!");
			}
        }
    }
}
