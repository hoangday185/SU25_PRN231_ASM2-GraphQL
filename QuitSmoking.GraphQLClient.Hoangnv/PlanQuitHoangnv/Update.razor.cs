using QuitSmoking.GraphQLClient.Hoangnv.Models;

namespace QuitSmoking.GraphQLClient.Hoangnv.PlanQuitHoangnv
{
    public partial class Update
    {
        public PlanQuitMethodHoangNv planQuitMethod = new();
        private string redirectUrl = "/PlanQuitHoangnv/Index";
        private bool isLoading = true;
        private bool isUpdated = false;
        private string? errorMsg;
        
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        public async Task HandleValidSubmit() { }
    }
}