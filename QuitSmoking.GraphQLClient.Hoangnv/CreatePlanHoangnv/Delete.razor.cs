using Microsoft.AspNetCore.Components;
using QuitSmoking.GraphQLClient.HoangNV.Models;

namespace QuitSmoking.GraphQLClient.Hoangnv.CreatePlanHoangnv
{
    public partial class Delete
    {
        [Parameter]
        public int Id { get; set; }
        private CreatePlanQuitSmokingHoangNv? plan;
        private bool isLoading = true;
        private bool isDeleted = false;
        private string? errorMsg;
        private string redirectUrl = "/CreatePlanHoangnv/index";

        protected override async Task OnInitializedAsync()
        {
            try
            {
                // Lấy thông tin kế hoạch theo Id bằng API GetPlanById
                plan = await _graphQLConsumer.GetPlanById(Id);
            }
            catch
            {
                plan = null;
            }
            isLoading = false;
        }

        private async Task OnDelete()
        {
            errorMsg = null;
            try
            {
                var result = await _graphQLConsumer.DeletePlan(Id);
                if (result)
                {
                    isDeleted = true;
                }
                else
                {
                    errorMsg = "Xóa thất bại!";
                }
            }
            catch
            {
                errorMsg = "Có lỗi xảy ra khi xóa!";
            }
        }
    }
}