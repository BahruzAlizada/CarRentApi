using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<CompanyDTO>> GetAllCompany();
        IDataResult<List<PersonDTO>> GetAllPerson();
        IDataResult<CompanyDTO> GetCompanyById(int id);
        IDataResult<PersonDTO> GetPersonById(int id);
        IResult AddCompany(CompanyDTO companyDto);
        IResult AddCustomer(PersonDTO personDto);
    }
}
