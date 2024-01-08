using NPaperless.DA.Entities;
using System;
using System.Linq;

namespace NPaperless.DA.Interfaces
{
    public interface IUserInfoRepository
    {
        public UserInfo GetById(long id);

        public IQueryable<UserInfo> GetAll();

        public void Add(UserInfo userInfo);

        public void Update(UserInfo userInfo);

        public void Delete(long id);
    }
}
