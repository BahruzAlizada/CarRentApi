using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using System;

namespace DataAccessLayer.Abstract
{
	public interface ISliderDal : IEntityRepository<Slider>
	{
		void Activity(int id);
	}
}
