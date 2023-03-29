using System;
using Microsoft.AspNetCore.Mvc;
using SchedulePlatform.Api.Mappings;
using SchedulePlatform.Api.Models.Patch;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service;
using SchedulePlatform.Service.Interfaces;

namespace SchedulePlatform.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]

        public Customer[] GetCustomers()
        {
            return _service.GetAllCustomers();
        }

        [HttpPost()]

        public Customer AddCustomer(Customer customer)
        {
            return _service.AddCustomer(customer);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(Guid id)
        {
            var customerResult = _service.GetById(id);

            if (customerResult == null)
            {
                return NotFound();
            }

            return Ok(customerResult);
        }

        [HttpPatch]

        public IActionResult Update(Guid id, CustomerPatchModel model)
        {
            var customerSearch = _service.GetById(id);

            if (customerSearch == null)
            {
                return NotFound();
            }

            var customerUpdated = customerSearch.Map(model);

            return Ok(_service.Update(customerUpdated));

        }

        [HttpDelete]

        public IActionResult Delete(Guid id, Customer customer)
        {
            var customerSearch = _service.GetById(id);

            if (customerSearch == null)
            {
                return NotFound();
            }

            return Ok(_service.Delete(id, customer));
        }
    }
}

