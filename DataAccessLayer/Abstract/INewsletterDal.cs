using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.Abstract
{
    public interface INewsletterDal : IEntityRepository<Newsletter>
    {
        public Task Subscribe(Newsletter newsletter);
    }
}
