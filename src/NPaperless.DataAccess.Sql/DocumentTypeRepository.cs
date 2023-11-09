using NPaperless.DataAccess.Entities;
using System;
using System.Linq;

namespace NPaperless.DataAccess.Sql
{
    public class DocumentTypeRepository
    {
        private readonly NPaperlessDbContext _dbContext;

        public DocumentTypeRepository(NPaperlessDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
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
        }
    }
}
