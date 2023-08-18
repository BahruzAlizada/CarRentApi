using BusinessLayer.Abstract;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarCountryMarketController : ControllerBase
    {
        private readonly ICarCountryMarketService carCountryMarketService;
        public CarCountryMarketController(ICarCountryMarketService carCountryMarketService)
        {
            this.carCountryMarketService=carCountryMarketService;
        }

        #region GetAll
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = carCountryMarketService.GetAll();
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
            var result = carCountryMarketService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        public IActionResult Add(CountryMarketDTO countryMarketDTO)
        {
            var result = carCountryMarketService.Add(countryMarketDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Update
        [HttpPost("Update")]
        public IActionResult Update(int id,CountryMarketDTO countryMarketDTO)
        {
            var result = carCountryMarketService.Update(countryMarketDTO);
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
            var result = carCountryMarketService.Activity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
