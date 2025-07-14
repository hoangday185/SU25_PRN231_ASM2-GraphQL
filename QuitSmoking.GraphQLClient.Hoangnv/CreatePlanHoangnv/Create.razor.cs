
using QuitSmoking.GraphQLClient.HoangNV.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using QuitSmoking.Repositories.HoangNV.ModelExtentions;

namespace QuitSmoking.GraphQLClient.Hoangnv.CreatePlanHoangnv
{
    public partial class Create
    {
        private CreatePlanQuitSmokingHoangNvCreateDto plan = new();
        private string redirectUrl = "/CreatePlanHoangnv/index";


        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(500);

            await Task.CompletedTask;   
        }

        private async Task HandleValidSubmit()
        {
            plan.UserAccountHoangNvid = 1;
            await _graphQLConsumer.CreatePlan(plan);
        }
    }
}