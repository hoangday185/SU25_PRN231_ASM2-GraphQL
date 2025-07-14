using Microsoft.AspNetCore.Components;
using QuitSmoking.GraphQLClient.Hoangnv.GraphQLClients;
using QuitSmoking.GraphQLClient.Hoangnv.Models;

namespace QuitSmoking.GraphQLClient.Hoangnv.QuitMethodHoangnv
{
    public partial class Delete
    {
        [Parameter]
        public int id { get; set; }

        private QuitMethodHoangNv? method;
        private bool isLoading = true;
        private bool isSubmitting = false;
        private string? errorMessage;
        private string? successMessage;
        private string redirectUrl = "QuitMethodHoangnv/index";

        protected override async Task OnInitializedAsync()
        {
            try
            {
                method = await _graphQLConsumer.GetQuitMethodById(id);
                if (method == null)
                {
                    errorMessage = "Không tìm thấy phương pháp.";
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            isLoading = false;
        }

        private async Task DeleteMethod()
        {
            isSubmitting = true;
            errorMessage = null;
            try
            {
                var result = await _graphQLConsumer.DeleteQuitMethod(id);
                if (result)
                {
                    successMessage = "Đã xóa thành công.";
                    await Task.Delay(1000);
                    _navigationManager.NavigateTo(redirectUrl, true);
                }
                else
                {
                    errorMessage = "Xóa thất bại.";
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            isSubmitting = false;
        }
    }
}