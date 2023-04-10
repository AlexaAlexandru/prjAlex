using System;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using SchedulePlatform.Shared.Models;
using SchedulePlatform.Models.Entities;

namespace SchedulePlatform.WebUI.Pages
{
    public partial class Confirmation
    {
        [Parameter]
        public Guid Id { get; set; }

        private AppointmentResponse Appointment = new();

        private NutritionistResponse Nutritionist = new();

        private ServiceResponse Service = new();

        private CustomerResponse Customer = new();

        private EmailRequest Email = new();

        private string Message { get; set; }

        protected async override Task OnParametersSetAsync()
        {
            var response = await HttpClient.GetFromJsonAsync<ApiResult<AppointmentResponse>>($"api/Appointments/{Id}");

            Appointment = new AppointmentResponse()
            {
                CustomerId = response.Result.CustomerId,
                NutritionistId = response.Result.NutritionistId,
                ServiceProvidedId = response.Result.ServiceProvidedId,
                StartDate = response.Result.StartDate,
                Type = response.Result.Type
            };

            var searchNutritionist = await HttpClient.GetFromJsonAsync<ApiResult<NutritionistResponse>>($"api/Nutritionists/{Appointment.NutritionistId}");

            Nutritionist = new NutritionistResponse()
            {
                FirstName = searchNutritionist.Result.FirstName,
                LastName = searchNutritionist.Result.LastName,
                PictureUrl = searchNutritionist.Result.PictureUrl,
                Phone = searchNutritionist.Result.Phone,
                Email = searchNutritionist.Result.Email
            };

            var searchService = await HttpClient.GetFromJsonAsync<ApiResult<ServiceResponse>>($"api/ServicesProvided/{Appointment.ServiceProvidedId}");

            Service = new ServiceResponse()
            {
                NameServiceProvided = searchService.Result.NameServiceProvided,
                Type = searchService.Result.Type
            };

            var searchCustomer = await HttpClient.GetFromJsonAsync<ApiResult<CustomerResponse>>($"api/Customers/{Appointment.CustomerId}");

            Customer = new CustomerResponse()
            {
                ScopeOfAppointment = searchCustomer.Result.ScopeOfAppointment,
                Email = searchCustomer.Result.Email,
                FirstName = searchCustomer.Result.FirstName,
                LastName = searchCustomer.Result.LastName
            };

            Email = new EmailRequest()
            {
                To = Customer.Email,
                Subject = $"Confirmation of Appointment {Appointment.Id}",
                Body = $"<h1>Scheduling platform is waiting for you</h1> <div> Resumem of your appointment : On the {Appointment.StartDate} , you will have an appoinment at {Nutritionist.FirstName} {Nutritionist.LastName}. See you there</div>"
            };

            var request = await HttpClient.PostAsJsonAsync("api/Email", Email);

        }
    }
}

