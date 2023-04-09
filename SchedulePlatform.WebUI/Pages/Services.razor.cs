using System;
using SchedulePlatform.Models.Entities;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections.Generic;
using SchedulePlatform.Shared.Models;
using Newtonsoft.Json.Linq;

namespace SchedulePlatform.WebUI.Pages
{
    public partial class Services
    {
        [Parameter]
        public Guid Id { get; set; }

        private List<ServiceResponse> services = new List<ServiceResponse>();

        protected override async Task OnInitializedAsync()
        {
            var response = await HttpClient.GetFromJsonAsync<ApiResult<IEnumerable<ServiceResponse>>>("api/ServicesProvided");
            services = response.Result.ToList();
        }
    }
}

