using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly INewsletterService newsletterService;

        public EmailsController(INewsletterService newsletterService)
        {
            this.newsletterService = newsletterService;
        }
         
        #region GetAll
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = newsletterService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Subscribe
        [HttpPost("Subscribe")]
        public async Task<IActionResult> Subscribe(Newsletter newsletter) 
        {
            var result = await newsletterService.Subscribe(newsletter);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
    