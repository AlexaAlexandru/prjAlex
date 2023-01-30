using System;
using Microsoft.AspNetCore.Mvc;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Service;

namespace SchedulePlatform.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class CustomerController : ControllerBase
    {

        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        [HttpGet]

        public Customer[] GetCustomers()
        {
            return _service.GetAllCustomers();
        }
    }
}

