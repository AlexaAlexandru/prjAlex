using System;
using System.Globalization;
using System.Net.Http.Json;
using System.Xml.Serialization;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Org.BouncyCastle.Security;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Shared.Models;

namespace SchedulePlatform.WebUI.Pages
{
    public partial class Appointment
    {
        public DateTime? DateTimeTest { get; set; } = DateTime.Today;

        [Parameter]
        public Guid ConfirmationId { get; set; }

        private Guid NutritionistId { get; set; }
        private TimeOnly hourAppointment { get; set; }

        private List<NutritionistResponse> nutritionists = new List<NutritionistResponse>();
        private List<ServiceResponse> services = new List<ServiceResponse>();
        private List<DateTime> availableSlots = new List<DateTime>();
        private List<CustomerResponse> customers = new List<CustomerResponse>();
        private List<AppointmentResponse> appointments = new List<AppointmentResponse>();

        private CustomerRequest customer = new();
        private CustomerResponse foundCustomer = new();
        private AppointmentRequest newAppointment = new();
        private AppointmentResponse foundAppoinment = new();

        private DateTime _requestDate = new DateTime();
        private DateTime _requestHour = new DateTime();
        private DateTime _requestDateTime = new DateTime();

        private string _response;
        private string _responseAppointment;

        public void DateValidator(MouseEventArgs e)
        {
            if (DateTimeTest?.DayOfWeek == DayOfWeek.Sunday || DateTimeTest?.DayOfWeek == DayOfWeek.Saturday)
            {
                JsRuntime.InvokeAsync<object>("window.alert", "Please select a day from Monday to Friday");
                DateTimeTest = null;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpClient.GetFromJsonAsync<ApiResult<IEnumerable<NutritionistResponse>>>("/api/Nutritionists");
            nutritionists = response.Result.ToList();
        }

        protected async Task HandleFreeSlots()
        {
            NutritionistId = newAppointment.NutritionistId;
            DateOnly dateOnly = DateOnly.FromDateTime((DateTime)DateTimeTest);

            string date = dateOnly.ToString();

            DateOnly dateParse = DateOnly.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var finalDate = dateParse.ToString("yyyy-MM-dd");

            var timeslots = await HttpClient.GetFromJsonAsync<List<DateTime>>($"api/Appointments/free/{finalDate}?nutritionistId={NutritionistId}");
            availableSlots = timeslots.ToList();
        }

        protected async Task HandleServicesByNutritionist(Guid nutritionistId)
        {
            if(nutritionistId == Guid.Empty) {
                nutritionistId = nutritionists.First().Id;
            }
            var servicesByNutritionist = await HttpClient.GetFromJsonAsync<ApiResult<IEnumerable<ServiceResponse>>>($"Api/ServicesProvided/all/{nutritionistId}");
            services = servicesByNutritionist.Result.ToList();
        }

        public async Task SubmitCustomer()
        {

            newAppointment.CustomerId = customer.Id;

            bool alertConfirmation = await JsRuntime.InvokeAsync<bool>("confirm", "Are all data correct?");
            if (alertConfirmation)
            {
                var request = await HttpClient.PostAsJsonAsync("api/Customers", customer);
                _response = await request.Content.ReadAsStringAsync();

                await JsRuntime.InvokeVoidAsync("alert", "your personal information was registered,please proceed with your appoinment remaing info: Date, nutritionist and service");

                var searchCustomers = await HttpClient.GetFromJsonAsync<ApiResult<IEnumerable<CustomerResponse>>>($"api/Customers");
                customers = searchCustomers.Result.ToList();
            }
        }

        public async Task SubmitAppointment()
        {
            _requestDate = (DateTime)DateTimeTest;
            _requestDateTime = _requestDate.Date.Add(_requestHour.TimeOfDay);

            newAppointment.StartDate = _requestDateTime;

            foundCustomer = customers.ToList().Find(x => x.Email == customer.Email);

            newAppointment.CustomerId = foundCustomer.Id;

            var serviceName = services.Find(x => x.Id == newAppointment.ServiceProvidedId);

            var nutritionistName = nutritionists.Find(n => n.Id == newAppointment.NutritionistId);

            Console.WriteLine(foundCustomer.Id);

            bool alertConfirmationAppointment = await JsRuntime.InvokeAsync<bool>("confirm", $" The appointment will be on the {newAppointment.StartDate}, for {serviceName.NameServiceProvided} at {nutritionistName.FirstName} {nutritionistName.LastName}. {foundCustomer.FirstName} are all informations correct?");

            if (alertConfirmationAppointment)
            {
                var request = await HttpClient.PostAsJsonAsync("api/Appointments", newAppointment);
                _responseAppointment = await request.Content.ReadAsStringAsync();

                await JsRuntime.InvokeVoidAsync("confirm", "The appointment was registered");

                var findappointmentsForCustomer = await HttpClient.GetFromJsonAsync<ApiResult<IEnumerable<AppointmentResponse>>>($"api/Appointments/all/{foundCustomer.Id}");

                appointments = findappointmentsForCustomer.Result.ToList();

                foundAppoinment = appointments.Find(a => a.StartDate == newAppointment.StartDate);

                ConfirmationId = foundAppoinment.Id;

                _nav.NavigateTo($"Confirmation/{ConfirmationId}");

            }
        }
    }
}

