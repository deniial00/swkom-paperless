using NPaperless.DA.Entities;
using NPaperless.DA.Interfaces;
using System;
using System.Linq;

namespace NPaperless.DA.Sql
{
    public class DocTagRepository : IDocTagRepository
    {
        private readonly NPaperlessDbContext _dbContext;

        public DocTagRepository(NPaperlessDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public DocTag GetById(long id)
        {
            return _dbContext.DocTags.Find(id);
        }

        public IQueryable<DocTag> GetAll()
        {
            return _dbContext.DocTags;
        }

        public void Add(DocTag docTag)
        {
            _dbContext.DocTags.Add(docTag);
            _dbContext.SaveChanges();
        }

        public void Update(DocTag docTag)
        {
            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var docTag = _dbContext.DocTags.Find(id);
            if (docTag != null)
            {
                _dbContext.DocTags.Remove(docTag);
                _dbContext.SaveChanges();
            }
        }
    }
}
