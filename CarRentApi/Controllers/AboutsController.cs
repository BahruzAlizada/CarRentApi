using BusinessLayer.Abstract;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService aboutService;
        public AboutsController(IAboutService aboutService)
        {
            this.aboutService=aboutService;
        }

        #region GetAboutById
        [HttpGet("GetAboutById/{id}")]
        public IActionResult GetAboutById(int id)
        {
            var result = aboutService.GetAboutById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetAbout
        [HttpGet("GetAbout")]
        public IActionResult GetAbout()
        {
            var result = aboutService.GetAbout();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Update
        [HttpPost("Update")]
        public IActionResult Update(int id,AboutDTO aboutDTO)
        {
            var result = aboutService.Update(aboutDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
