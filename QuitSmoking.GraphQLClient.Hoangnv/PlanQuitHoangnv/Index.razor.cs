using Microsoft.AspNetCore.Components;
using QuitSmoking.GraphQLClient.Hoangnv.Models;

namespace QuitSmoking.GraphQLClient.Hoangnv.PlanQuitHoangnv
{
    public partial class Index
    {
        [Parameter]
        public int Id { get; set; }

        public List<PlanQuitMethodHoangNv> listPlanQuitMethods;
      
        protected override async Task OnInitializedAsync()
        {
            try
            {
                listPlanQuitMethods = await _graphQLConsumer.GetAllPlanQuitMethodsByCreateId(Id);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}