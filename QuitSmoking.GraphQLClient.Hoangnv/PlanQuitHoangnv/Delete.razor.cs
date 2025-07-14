using Microsoft.AspNetCore.Components;
using QuitSmoking.GraphQLClient.Hoangnv.Models;

namespace QuitSmoking.GraphQLClient.Hoangnv.PlanQuitHoangnv
{
    public partial class Delete
    {
        [Parameter]
        public int Id { get; set; }

        private string redirectUrl = "/PlanQuitHoangnv/Index";
        private PlanQuitMethodHoangNv planQuitMethod;

        private bool isLoading = true;
        private bool isDeleted = false;
        private string? errorMsg;
        protected override async Task OnInitializedAsync()
        {
            // Khởi tạo dữ liệu cần thiết cho trang xóa kế hoạch bỏ thuốc
            await base.OnInitializedAsync();
        }

        public async Task OnDelete()
        {

        }
    }
}