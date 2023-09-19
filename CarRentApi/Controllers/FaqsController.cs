using BusinessLayer.Abstract;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqsController : ControllerBase
    {
        private readonly IFaqService faqService;
        public FaqsController(IFaqService faqService)
        {
            this.faqService= faqService;
        }

        #region GetAll
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = faqService.GetFaqs();
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
            var result = faqService.GetFaq(id);
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
            var result = faqService.Activity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        public IActionResult Add(FaqDTO faqDTO)
        {
            var result = faqService.Add(faqDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Update
        [HttpPost("Update")]
        public IActionResult Update(int id,FaqDTO faqDTO)
        {
            var result = faqService.Update(faqDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
