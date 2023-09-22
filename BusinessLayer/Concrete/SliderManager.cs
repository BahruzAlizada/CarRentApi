using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Constans;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Utilities.Business;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Concrete
{
	public class SliderManager : ISliderService
	{
		private readonly ISliderDal sliderDal;
		private readonly IMapper mapper;
        public SliderManager(ISliderDal sliderDal,IMapper mapper)
        {
			this.sliderDal = sliderDal;
			this.mapper = mapper;
        }

		#region Activity
		public IResult Activity(int id)
		{
			sliderDal.Activity(id);
			return new SuccessResult(Message.Status);
		}
		#endregion

		#region Add
		[ValidationAspect(typeof(SliderValidator))]
		public IResult Add(SliderDTO sliderDTO)
		{
			var result = BusinessRules.Run(CheckIfNameExisted(sliderDTO.Title));
			if(result != null)
			{
				return result;
			}
			var slider = mapper.Map<Slider>(sliderDTO);
			sliderDal.Add(slider);
			return new SuccessResult(Message.Added);
		}
		#endregion

		#region GetSlider
		public IDataResult<Slider> GetSlider(int id)
		{
			var value = sliderDal.Get(x => x.Id == id);
			return new SuccessDataResult<Slider>(value, Message.ByFilter);
		}
		#endregion

		#region GetSliders
		public IDataResult<List<Slider>> GetSliders()
		{
			var values = sliderDal.GetAll();
			return new SuccessDataResult<List<Slider>>(values, Message.GetAll);
		}
		#endregion

		#region Update
		[ValidationAspect(typeof(SliderValidator))]
		public IResult Update(SliderDTO sliderDTO)
		{
			var result = BusinessRules.Run(CheckIfNameExisted(sliderDTO.Title));
			if (result != null)
			{
				return result;
			}
			var slider = mapper.Map<Slider>(sliderDTO);
			sliderDal.Update(slider);
			return new SuccessResult(Message.Updated);
		}
		#endregion






		#region Business Rules
		private IResult CheckIfNameExisted(string name)
		{
			var result = sliderDal.GetAll().Any(x=>x.Title == name);
			if (result)
			{
				return new ErrorResult(Message.NameExisted);
			}
			return new SuccessResult();
		}

		private IResult CheckIfNameExistedForUpdate(int id,string name)
		{
			var result = sliderDal.GetAll().Any(x => x.Title == name && x.Id!=id);
			if (result)
			{
				return new ErrorResult(Message.NameExisted);
			}
			return new SuccessResult();
		}
		#endregion
	}
}
