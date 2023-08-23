using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.EntityFramework
{
    public class EFNewsletterDal : EfEntityRepositoryBase<Newsletter, Context>, INewsletterDal
    {
        public async Task Subscribe(Newsletter newsletter)
        {
            using (var context = new Context())
            {
                await context.Newsletters.AddAsync(newsletter);
                await context.SaveChangesAsync(); 
            }
        }
    }
}
