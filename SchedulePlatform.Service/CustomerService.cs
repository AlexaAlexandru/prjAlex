using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using SchedulePlatform.Data.Interfaces;
using SchedulePlatform.Data.Repositories;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service.Interfaces;
using SchedulePlatform.Service.Models.Customer;
using SchedulePlatform.Service.Models.Nutritionist;

namespace SchedulePlatform.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public CustomerResponseModel AddCustomer(CustomerCreateModel customer)
        {

            var customerToAdd = _mapper.Map<Customer>(customer);

            _customerRepository.Add(customerToAdd);

            return _mapper.Map<CustomerResponseModel>(customerToAdd);
        }

        public CustomerResponseModel GetById(Guid id)
        {
            var findCustomer = _customerRepository.GetById(id);

            return _mapper.Map<CustomerResponseModel>(findCustomer);
        }

        public UpdateCustomerResponseModel Update(UpdateCustomerRequestModel model)
        {
            var updateCustomer = _mapper.Map<Customer>(model);
            _customerRepository.Update(updateCustomer);

            return _mapper.Map<UpdateCustomerResponseModel>(updateCustomer);

        }

        public CustomerResponseModel Delete(Guid id)
        {
            var findCustomer = _customerRepository.GetById(id);

            _customerRepository.Delete(findCustomer);

            return _mapper.Map<CustomerResponseModel>(findCustomer);
        }
    }
}

