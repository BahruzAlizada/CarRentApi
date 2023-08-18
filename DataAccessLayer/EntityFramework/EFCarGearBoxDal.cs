using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;


namespace DataAccessLayer.EntityFramework
{
    public class EFCarGearBoxDal : EfEntityRepositoryBase<CarGearBox,Context>,ICarGearBoxDal
    {
        public void Activity(int id)
        {
            using (var context = new Context())
            {
                var gearBox = context.CarGearBoxes.FirstOrDefault(x => x.Id == id);
                if (gearBox.Status)
                    gearBox.Status = false;
                else
                    gearBox.Status = true;

                context.SaveChanges();
            }
        }

        public List<GearBoxDTO> GetAllForHome()
        {
            using (var context = new Context())
            {
                List<CarGearBox> gearBoxes = context.CarGearBoxes.ToList();
                List<GearBoxDTO> gearBoxDTOs = new List<GearBoxDTO>();

                foreach (var item in gearBoxes)
                {
                    GearBoxDTO dto = new GearBoxDTO
                    {
                        Id = item.Id,
                        GearBox = item.GearBox,
                    };
                    gearBoxDTOs.Add(dto);
                }
                return gearBoxDTOs;
            }
        }

        public GearBoxDTO GetByIdForHome(int id)
        {
            using (var context = new Context())
            {
                var gearBox = context.CarGearBoxes.FirstOrDefault(x => x.Id == id);
                GearBoxDTO boxDTO = new GearBoxDTO
                {
                    Id = gearBox.Id,
                    GearBox = gearBox.GearBox,
                };
                return boxDTO;
            }
        }
    }
}
