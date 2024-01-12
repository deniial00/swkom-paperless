using NPaperless.DA.Entities;
using NPaperless.DA.Interfaces;
using System;
using System.Linq;

namespace NPaperless.DA.Sql
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly NPaperlessDbContext _dbContext;

        public UserInfoRepository(NPaperlessDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new DAException(nameof(dbContext));
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
			else{
				throw new DAException("Error: No userInfo with the id " + id + " was found!");
			}
        }
    }
}
