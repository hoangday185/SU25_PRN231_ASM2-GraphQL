using Microsoft.AspNetCore.Components;
using QuitSmoking.GraphQLClient.HoangNV.Models;

namespace QuitSmoking.GraphQLClient.Hoangnv.CreatePlanHoangnv
{
    public partial class Index : ComponentBase
    {

        private List<CreatePlanQuitSmokingHoangNv> listPlan = new();
        protected override async Task OnInitializedAsync()
        {
            listPlan = await _graphQLConsumer.GetAllPlans();
        }
    }
}