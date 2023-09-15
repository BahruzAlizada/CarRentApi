using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService carService;
        public CarsController(ICarService carService)
        {
            this.carService=carService;
        }

        #region GetCars
        [HttpGet("GetCars")]
        public IActionResult GetCars()
        {
            var result = carService.GetCars();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetByIdCars
        [HttpGet("GetByCarId/{id}")]
        public IActionResult GetByCarId(int id)
        {
            var result = carService.GetByIdCar(id);
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
            var result = carService.Activity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Delete
        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = carService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
