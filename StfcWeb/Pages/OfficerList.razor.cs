using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StfcWeb.Pages
{
    public partial class OfficerList
    {
        private List<Data.Entities.Officer> officers = new List<Data.Entities.Officer>();

        protected override async Task OnInitializedAsync()
        {
            //forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
        }
    }
}
