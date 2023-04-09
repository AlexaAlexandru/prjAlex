using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchedulePlatform.Api.Mappings;
using SchedulePlatform.Api.Models.Patch;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service;
using SchedulePlatform.Service.Interfaces;
using SchedulePlatform.Service.Models;
using SchedulePlatform.Service.Models.Customer;
using SchedulePlatform.Service.Models.Nutritionist;

namespace SchedulePlatform.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class CustomersController : ControllerBase
    {

        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<Customer>>.Success(_service.GetAllCustomers()));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<Customer>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpPost()]

        public IActionResult AddCustomer(CustomerCreateModel customer)
        {
            try
            {
                return Ok(ApiGenericsResult<CustomerResponseModel>.Success(_service.AddCustomer(customer)));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<CustomerResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            var customerResult = _service.GetById(id);

            if (customerResult==null)
            {
                return NotFound();
            }
            try
            {
                return Ok(ApiGenericsResult<CustomerResponseModel>.Success(_service.GetById(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]

        public IActionResult Update(Guid id, CustomerPatchModel model)
        {
            var customerSearch = _service.GetById(id);
            if (customerSearch==null)
            {
                return NotFound();
            }
            try
            {
                var updateCustomer = customerSearch.Map(model);
                var mappedCustomer = _mapper.Map<UpdateCustomerRequestModel>(updateCustomer);
                return Ok(ApiGenericsResult<UpdateCustomerResponseModel>.Success(_service.Update(mappedCustomer)));
            }
            catch (Exception ex)
            {
                return NotFound(ApiGenericsResult<UpdateCustomerResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpDelete]

        public IActionResult Delete(Guid id)
        {
            var customerSearch = _service.GetById(id);

            if (customerSearch == null)
            {
                return NotFound();
            }
            try
            {
                return Ok(ApiGenericsResult<CustomerResponseModel>.Success(_service.Delete(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<CustomerResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }
    }
}

