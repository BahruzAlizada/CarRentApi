using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace DataAccessLayer.EntityFramework
{
    public class EFBanDal : EfEntityRepositoryBase<Ban, Context>, IBanDal
    {
        public void Activity(int id)
        {
            using (var context = new Context())
            {
                var ban = context.Bans.FirstOrDefault(x => x.Id == id);
                if(ban.Status)
                    ban.Status = false;
                else
                    ban.Status=true;

                context.SaveChanges();
            }
        }

        public List<BanDTO> GetAllForHome()
        {
            using (var context = new Context())
            {
                List<Ban> bans = context.Bans.ToList();
                List<BanDTO> banDTOs = new List<BanDTO>();

                foreach (var item in bans)
                {
                    BanDTO dto = new BanDTO
                    {
                        Id = item.Id,
                        BanName = item.BanName
                    };
                    banDTOs.Add(dto);
                }
                return banDTOs;
            }
        }

        public BanDTO GetByIdForHome(int id)
        {
            using (var context = new Context())
            {
                Ban ban = context.Bans.FirstOrDefault(x => x.Id == id);
                BanDTO banDTO = new BanDTO
                {
                    Id = ban.Id,
                    BanName = ban.BanName
                };
                return banDTO;
            }
        }
    }
}
