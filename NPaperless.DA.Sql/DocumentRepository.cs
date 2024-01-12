using Microsoft.Extensions.Logging;
using NPaperless.DA.Entities;
using NPaperless.DA.Interfaces;
using System;
using System.Linq;

namespace NPaperless.DA.Sql
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly NPaperlessDbContext _dbContext;
		private readonly ILogger<DocumentRepository> _logger;

        public DocumentRepository(NPaperlessDbContext dbContext, ILogger<DocumentRepository> logger)
        {
            _dbContext = dbContext ?? throw new DAException(nameof(dbContext));
			_logger = logger;
        }

        public Document GetById(int id)
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

        public void Delete(int id)
        {
            var document = _dbContext.Documents.Find(id);
            if (document != null)
            {
                _dbContext.Documents.Remove(document);
                _dbContext.SaveChanges();
				_logger.LogDebug("Document with id '" + id + "' has been successfully deleted");
            }
			else{
				_logger.LogError("Error in method Delete: No Document with the id " + id + " was found!");
				throw new DAException("Error in method Delete: No Document with the id " + id + " was found!");
			}
        }
    }
}
