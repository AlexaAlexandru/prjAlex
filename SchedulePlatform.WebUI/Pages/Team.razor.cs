using System;
using System.Net.Http.Json;
using SchedulePlatform.Models.Entities;
using SchedulePlatform.Shared.Models;

namespace SchedulePlatform.WebUI.Pages
{
    public partial class Team
    {
        private List<NutritionistResponse> nutritionists = new List<NutritionistResponse>();

        protected async override Task OnParametersSetAsync()
        {
            var response = await HttpClient.GetFromJsonAsync<ApiResult<IEnumerable<NutritionistResponse>>>("api/Nutritionist");
            nutritionists = response.Result.ToList();
        }
    }
}

