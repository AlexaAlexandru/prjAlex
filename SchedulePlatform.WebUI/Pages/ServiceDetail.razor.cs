using System;
using Microsoft.AspNetCore.Components;
using SchedulePlatform.Shared.Models;
using System.Net.Http.Json;

namespace SchedulePlatform.WebUI.Pages
{
    public partial class ServiceDetail
    {
        [Parameter]
        public Guid Id { get; set; }
        private ServiceResponse Service = new ServiceResponse();

        protected async override Task OnParametersSetAsync()
        {
            var response = await HttpClient.GetFromJsonAsync<ApiResult<ServiceResponse>>($"api/ServiceProvided/{Id}");

            Service = new ServiceResponse()
            {
                NameServiceProvided = response.Result.NameServiceProvided,
                Description = response.Result.Description,
                NutritionistService = response.Result.NutritionistService,
                Price = response.Result.Price,
                Type = response.Result.Type,
                UrlPicture = response.Result.UrlPicture
            };
        }


        void Navigate()
        {
            _nav.NavigateTo("/Appointment");
        }
    }
}

