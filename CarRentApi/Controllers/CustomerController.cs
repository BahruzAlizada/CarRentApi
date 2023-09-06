using BusinessLayer.Abstract;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService; 
        }

        #region GetAllCompany
        [HttpGet("GetAllCompany")]
        public IActionResult GetAllCompany()
        {
            var result = customerService.GetAllCompany();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetAllCustomer
        [HttpGet("GetAllCustomer")]
        public IActionResult GetAllCustomer()
        {
            var result = customerService.GetAllPerson();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetCompanyById
        [HttpGet("GetCompanyById/{id}")]
        public IActionResult GetCompanyById(int id)
        {
            var result = customerService.GetCompanyById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region GetCustomerById
        [HttpGet("GetCustomerById/{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var result = customerService.GetPersonById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region CompanyCreate
        [HttpPost("CreateCompany")]
        public IActionResult CreateCompany(CompanyDTO companyDTO)
        {
            var result = customerService.AddCompany(companyDTO);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion

        #region CreatePerson
        [HttpPost("CreatePerson")]
        public IActionResult CreateCompany(PersonDTO personDTO)
        {
            var result = customerService.AddCustomer(personDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}
