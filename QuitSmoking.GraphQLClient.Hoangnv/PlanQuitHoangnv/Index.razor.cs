using QuitSmoking.GraphQLClient.Hoangnv.Models;

namespace QuitSmoking.GraphQLClient.Hoangnv.PlanQuitHoangnv
{
    public partial class Index
    {
        public List<PlanQuitMethodHoangNv> listPlanQuitMethods;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                listPlanQuitMethods = await _graphQLConsumer.GetAllPlanQuitMethods();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}