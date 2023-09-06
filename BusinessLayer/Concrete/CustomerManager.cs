using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Constans;
using BusinessLayer.ValidationRules.FluentValidation;
using CoreLayer.Aspects.Autofac.Validation;
using CoreLayer.Utilities.Business;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal customerDal;
        private readonly IMapper mapper;
        public CustomerManager(ICustomerDal customerDal,IMapper mapper)
        {
            this.customerDal = customerDal;
            this.mapper = mapper;
        }

        #region AddCompany
        [ValidationAspect(typeof(CustomerCompanyValidator))]
        public IResult AddCompany(CompanyDTO companyDto)
        {
            var result = BusinessRules.Run(CheckIfEmailExisted(companyDto.Email));
            if(result != null)
            {
                return result;
            }
            var company = mapper.Map<Customer>(companyDto);
            company.IsCompany = true;
            customerDal.Add(company);
            return new SuccessResult(Message.Added);
        }
        #endregion

        #region AddPerson
        [ValidationAspect(typeof(CustomerPersonValidator))]
        public IResult AddCustomer(PersonDTO personDto)
        {
            var result = BusinessRules.Run(CheckIfEmailExisted(personDto.Email));
            if(result != null)
            {
                return result;
            }
            var customer = mapper.Map<Customer>(personDto);
            customer.IsCompany = false;
            customerDal.Add(customer);
            return new SuccessResult(Message.Added);
        }
        #endregion

        #region GetAllCompany
        public IDataResult<List<CompanyDTO>> GetAllCompany()
        {
            var values = customerDal.GetAllCompany();
            return new SuccessDataResult<List<CompanyDTO>>(values,Message.GetAll);
        }
        #endregion

        #region GetAllPerson
        public IDataResult<List<PersonDTO>> GetAllPerson()
        {
            var values = customerDal.GetAllCustomer();
            return new SuccessDataResult<List<PersonDTO>>(values,Message.GetAll);
        }
        #endregion

        #region GetCompanyById
        public IDataResult<CompanyDTO> GetCompanyById(int id)
        {
            var value = customerDal.GetByIdCompany(id);
            return new SuccessDataResult<CompanyDTO>(value, Message.ByFilter);
        }
        #endregion

        #region GetCustomerById
        public IDataResult<PersonDTO> GetPersonById(int id)
        {
            var value = customerDal.GetByIdCustomer(id);
            return new SuccessDataResult<PersonDTO>(value, Message.ByFilter);
        }
        #endregion


        #region BusinessCode
        private IResult CheckIfEmailExisted(string email)
        {
            var result = customerDal.GetAll().Any(x=>x.Email== email);
            if (result)
            {
                return new ErrorResult(Message.NameExisted);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
