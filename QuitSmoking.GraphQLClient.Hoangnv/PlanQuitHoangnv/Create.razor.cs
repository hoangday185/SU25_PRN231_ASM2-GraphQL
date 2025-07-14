using QuitSmoking.GraphQLClient.Hoangnv.Models;

namespace QuitSmoking.GraphQLClient.Hoangnv.PlanQuitHoangnv
{
    public partial class Create
    {
        private PlanQuitMethodHoangNv plan = new();
        private string redirectUrl = "/PlanQuitHoangnv/Index";
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        public async Task HandleValidSubmit()
        {
            try
            {
                //var result = await _graphQLConsumer.Cre
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}