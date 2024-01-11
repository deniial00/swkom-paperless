using NPaperless.DA.Entities;
using NPaperless.DA.Interfaces;
using System;
using System.Linq;

namespace NPaperless.DA.Sql
{
    public class CorrespondentRepository : ICorrespondentRepository
    {
        private readonly NPaperlessDbContext _dbContext;

        public CorrespondentRepository(NPaperlessDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new DAException(nameof(dbContext));
        }

        public Correspondent GetById(long id)
        {
            return _dbContext.Correspondents.Find(id);
        }

        public IQueryable<Correspondent> GetAll()
        {
            return _dbContext.Correspondents;
        }

        public void Add(Correspondent correspondent)
        {
            _dbContext.Correspondents.Add(correspondent);
            _dbContext.SaveChanges();
        }

        public void Update(Correspondent correspondent)
        {
            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var correspondent = _dbContext.Correspondents.Find(id);
            if (correspondent != null)
            {
                _dbContext.Correspondents.Remove(correspondent);
                _dbContext.SaveChanges();
            }
			else{
				throw new DAException("Error: No correspondend with the id " + id + " was found!");
			}
        }
    }
}
