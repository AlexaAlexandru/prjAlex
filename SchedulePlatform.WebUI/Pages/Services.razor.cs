using System;
using SchedulePlatform.Models.Entities;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace SchedulePlatform.WebUI.Pages
{
    public partial class Services
    {
        [Parameter]
        public Guid Id { get; set; }

        private List<ServiceProvided> services = new List<ServiceProvided>();

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpClient.GetAsync("api/ServiceProvided");
            var json = await response.Content.ReadAsStringAsync();

            services = JsonConvert.DeserializeObject<List<ServiceProvided>>(json);

        }
    }

    
}

