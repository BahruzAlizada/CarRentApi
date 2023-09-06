using CoreLayer.DataAccess;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;


namespace DataAccessLayer.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<CompanyDTO> GetAllCompany();
        List<PersonDTO> GetAllCustomer();
        CompanyDTO GetByIdCompany(int id);
        PersonDTO GetByIdCustomer(int id);
    }
}
