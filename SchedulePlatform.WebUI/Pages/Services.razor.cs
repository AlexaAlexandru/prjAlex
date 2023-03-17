using System;
using SchedulePlatform.Models.Entities;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

namespace SchedulePlatform.WebUI.Pages
{
    public partial class Services
    {
        private List<ServiceProvided> services = new List<ServiceProvided>();

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpClient.GetAsync("api/ServiceProvided");
            var json = await response.Content.ReadAsStringAsync();

            services = JsonConvert.DeserializeObject<List<ServiceProvided>>(json);

        }
    }
}

