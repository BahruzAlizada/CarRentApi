using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoryService subCategoryService;
        public SubCategoriesController(ISubCategoryService subCategoryService)
        {
            this.subCategoryService = subCategoryService;
        }

        #region GetAll
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = subCategoryService.GetAll();
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
            var result = subCategoryService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Add
        [HttpPost("Add")]
        public IActionResult Add(SubCategoryDTO subCategoryDTO)
        {
            var result = subCategoryService.Add(subCategoryDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region Update
        [HttpPost("Update")]
        public IActionResult Update(int id,SubCategoryDTO subCategoryDTO)
        {
            var result = subCategoryService.Update(subCategoryDTO);
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
            var result = subCategoryService.Activity(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
