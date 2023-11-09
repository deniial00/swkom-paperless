using NPaperless.DataAccess.Entities;
using System;
using System.Linq;

namespace NPaperless.DataAccess.Sql
{
    public class UserInfoRepository
    {
        private readonly NPaperlessDbContext _dbContext;

        public UserInfoRepository(NPaperlessDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public UserInfo GetById(long id)
        {
            return _dbContext.UserInfos.Find(id);
        }

        public IQueryable<UserInfo> GetAll()
        {
            return _dbContext.UserInfos;
        }

        public void Add(UserInfo userInfo)
        {
            _dbContext.UserInfos.Add(userInfo);
            _dbContext.SaveChanges();
        }

        public void Update(UserInfo userInfo)
        {
            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var userInfo = _dbContext.UserInfos.Find(id);
            if (userInfo != null)
            {
                _dbContext.UserInfos.Remove(userInfo);
                _dbContext.SaveChanges();
            }
        }
    }
}
