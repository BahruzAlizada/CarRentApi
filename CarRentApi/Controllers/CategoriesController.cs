using BusinessLayer.Abstract;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarRentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        #region GetAllWithSubCategories
        [HttpGet("GetAllWithSubCategories")]
        public IActionResult GetAllWithSubCategories()
        {
            var result = categoryService.GetAllWithSubCategories();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetByidWithSubCategories
        [HttpGet("GetByidWithSubCategories/{id}")]
        public IActionResult GetByidWithSubCategories(int id)
        {
            var result = categoryService.GetByIdWithSubCategories(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
		#endregion

		#region GetAllJustCategories
		[HttpGet("GetAllJustCategories")]
        public IActionResult GetAllJustCategories()
        {
            var result = categoryService.GetAllJustCategory();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetByIdJustCategory
        [HttpGet("GetByIdJustCategory")]
        public IActionResult GetByIdJustCategory(int id)
        {
            var result = categoryService.GetByIdJustCategory(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        public IActionResult Add(CategoryDTO categoryDTO)
        {
            var result = categoryService.Add(categoryDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion 

        #region Update
        [HttpPost("Update")]
        public IActionResult Update(CategoryDTO categoryDTO)
        {
            var result = categoryService.Update(categoryDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Activity
        [HttpGet("Activity")]
        public IActionResult Activity(int id)
        {
            var result = categoryService.Activity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion   
    }            
}
