using NPaperless.DA.Entities;
using NPaperless.DA.Interfaces;
using System;
using System.Linq;

namespace NPaperless.DA.Sql
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly NPaperlessDbContext _dbContext;

        public DocumentRepository(NPaperlessDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new DAException(nameof(dbContext));
        }

        public Document GetById(long id)
        {
            return _dbContext.Documents.Find(id);
        }

        public IQueryable<Document> GetAll()
        {
            return _dbContext.Documents;
        }

        public void Add(Document document)
        {
            _dbContext.Documents.Add(document);
            _dbContext.SaveChanges();
        }

        public void Update(Document document)
        {
            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var document = _dbContext.Documents.Find(id);
            if (document != null)
            {
                _dbContext.Documents.Remove(document);
                _dbContext.SaveChanges();
            }
			else{
				throw new DAException("Error: No Document with the id " + id + " was found!");
			}
        }
    }
}
