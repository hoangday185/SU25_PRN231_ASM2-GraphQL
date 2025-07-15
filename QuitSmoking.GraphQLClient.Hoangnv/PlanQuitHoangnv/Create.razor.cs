using QuitSmoking.GraphQLClient.Hoangnv.Models;

namespace QuitSmoking.GraphQLClient.Hoangnv.PlanQuitHoangnv
{
    public partial class Create
    {
        private PlanQuitHoangnvCreateDto plan = new();
        private string redirectUrl = "/PlanQuitHoangnv/Index";
        public List<QuitMethodHoangNv> listMethod;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                listMethod = await _graphQLConsumer.GetAllQuitMethods()!;
            }
            catch
            {

            }

        }

        public async Task HandleValidSubmit()
        {
            try
            {
                plan.CreatePlanQuitSmokingHoangNvid = 28;
                await _graphQLConsumer.CreatePlanQuitMethod(plan);
               // _navigationManager.NavigateTo(redirectUrl, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}