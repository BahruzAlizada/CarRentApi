using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace DataAccessLayer.EntityFramework
{
    public class EFCustomerDal : EfEntityRepositoryBase<Customer, Context>, ICustomerDal
    {
        #region GetAllCompany
        public List<CompanyDTO> GetAllCompany()
        {
            using (var context = new Context())
            {
                List<Customer> customers = context.Customers.Where(x => x.IsCompany).ToList();
                List<CompanyDTO> companyDtos = new List<CompanyDTO>();

                foreach (var item in customers)
                {
                    CompanyDTO dto = new CompanyDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Address = item.Address,
                        Email = item.Email,
                        PhoneNumber = item.PhoneNumber,
                        Description = item.Description
                    };
                    companyDtos.Add(dto);
                }
                return companyDtos;
            }
        }
        #endregion

        #region GetAllCustomer
        public List<PersonDTO> GetAllCustomer()
        {
            using (var context = new Context())
            {
                List<Customer> customers = context.Customers.Where(x => !x.IsCompany).ToList();
                List<PersonDTO> personDTOs = new List<PersonDTO>();

                foreach (var item in customers)
                {
                    PersonDTO dto = new PersonDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Email = item.Email,
                        PhoneNumber = item.PhoneNumber,
                    };
                    personDTOs.Add(dto);
                }
                return personDTOs;
            }
        }
        #endregion

        #region GetByIdCompany
        public CompanyDTO GetByIdCompany(int id)
        {
            using (var context = new Context())
            {
                Customer customer = context.Customers.Where(x => x.IsCompany).FirstOrDefault(x => x.Id == id);
                CompanyDTO companyDTO = new CompanyDTO
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Address = customer.Address,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    Description = customer.Description
                };
                return companyDTO;
            }
        }
        #endregion

        #region GetByIdCustomer
        public PersonDTO GetByIdCustomer(int id)
        {
            using (var context = new Context())
            {
                Customer customer = context.Customers.Where(x => !x.IsCompany).FirstOrDefault(x => x.Id == id);
                PersonDTO personDTO = new PersonDTO
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                };
                return personDTO;
            }
        }
        #endregion
    }
}
