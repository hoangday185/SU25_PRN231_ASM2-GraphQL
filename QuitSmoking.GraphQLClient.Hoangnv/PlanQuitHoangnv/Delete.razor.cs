using Microsoft.AspNetCore.Components;
using QuitSmoking.GraphQLClient.Hoangnv.Models;

namespace QuitSmoking.GraphQLClient.Hoangnv.PlanQuitHoangnv
{
    public partial class Delete
    {
        [Parameter]
        public int Id { get; set; }

        [Parameter]
        [SupplyParameterFromQuery]
        public int? CreateId { get; set; } // Nếu muốn redirect về đúng kế hoạch cha

        private string redirectUrl => CreateId.HasValue ? $"/PlanQuitHoangnv/Index/{CreateId}" : "/PlanQuitHoangnv/Index";
        private PlanQuitMethodHoangNv planQuitMethod;

        private bool isLoading = true;
        private bool isDeleted = false;
        private string? errorMsg;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                isLoading = true;
                planQuitMethod = await _graphQLConsumer.GetPlanQuitMethodById(Id);
                if (planQuitMethod == null)
                {
                    errorMsg = "Không tìm thấy phương pháp!";
                }
            }
            catch (Exception ex)
            {
                errorMsg = $"Lỗi: {ex.Message}";
            }
            finally
            {
                isLoading = false;
            }
        }

        public async Task OnDelete()
        {
            try
            {
                isLoading = true;
                var result = await _graphQLConsumer.DeletePlanQuitMethod(Id);
                if (result)
                {
                    isDeleted = true;
                }
                else
                {
                    errorMsg = "Xóa thất bại!";
                }
            }
            catch (Exception ex)
            {
                errorMsg = $"Lỗi: {ex.Message}";
            }
            finally
            {
                isLoading = false;
            }
        }
    }
}