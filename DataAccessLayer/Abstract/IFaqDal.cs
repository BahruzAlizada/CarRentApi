using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.Abstract
{
    public interface IFaqDal : IEntityRepository<Faq>
    {
        void Activity(int id);
    }
}
