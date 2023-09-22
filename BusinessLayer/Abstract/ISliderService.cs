using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
namespace BusinessLayer.Abstract
{
	public interface ISliderService
	{
		IDataResult<List<Slider>> GetSliders();
		IDataResult<Slider> GetSlider(int id);
		IResult Add(SliderDTO sliderDTO);
		IResult Update(SliderDTO sliderDTO);
		IResult Activity(int id);
	}
}
