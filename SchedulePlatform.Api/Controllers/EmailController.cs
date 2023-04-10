using System;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using SchedulePlatform.Service.Interfaces;
using SchedulePlatform.Service.Models;

namespace SchedulePlatform.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailToSend request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }
    }
}

