using BusinessLayer.Abstract;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SlidersController : ControllerBase
	{
        private readonly ISliderService sliderService;
        public SlidersController(ISliderService sliderService)
        {
            this.sliderService = sliderService;
        }

		#region GetAll
		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = sliderService.GetSliders();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		#endregion

		#region GetById
		[HttpGet("GetById/{id}")]
		public IActionResult GetById(int id)
		{
			var result = sliderService.GetSlider(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		#endregion

		#region Activity
		[HttpGet("Activity/{id}")]
		public IActionResult Activity(int id)
		{
			var result = sliderService.Activity(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		#endregion

		#region Add
		[HttpPost("Add")]
		public IActionResult Add(SliderDTO sliderDTO)
		{
			var result = sliderService.Add(sliderDTO);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		#endregion

		#region Update
		[HttpPost("Update")]
		public IActionResult Update(int id,SliderDTO sliderDTO)
		{
			var result = sliderService.Update(sliderDTO);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		#endregion
	}
}
