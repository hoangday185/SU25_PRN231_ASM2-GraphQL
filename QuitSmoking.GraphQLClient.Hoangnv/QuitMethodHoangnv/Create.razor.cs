using QuitSmoking.GraphQLClient.Hoangnv.Models;

namespace QuitSmoking.GraphQLClient.Hoangnv.QuitMethodHoangnv
{
    public partial class Create
    {
        private QuitMethodHoangNv method = new();
        private bool isSubmitting = false;
        private string? errorMessage;
        private string? redirectUrl = "/QuitmethodHoangnv/Index";
        
        private bool RequiresMedical
        {
            get => method.RequiresMedical ?? false;
            set => method.RequiresMedical = value;
        }
        private bool RequiresCounseling
        {
            get => method.RequiresCounseling ?? false;
            set => method.RequiresCounseling = value;
        }
        private bool IsPopular
        {
            get => method.IsPopular ?? false;
            set => method.IsPopular = value;
        }

        private async Task HandleValidSubmit()
        {
            isSubmitting = true;
            errorMessage = null;
            try
            {
                // Đặt mặc định cho các trường không nhập
                method.IsActive = true;
                method.CreationDateTime = DateTime.Now;
                var result = await _graphQLConsumer.CreateQuitMethod(method);
                if (result != null && result.QuitMethodHoangNvid > 0)
                {
                    _navigationManager.NavigateTo("/QuitMethodHoangnv", true);
                }
                else
                {
                    errorMessage = "Tạo phương pháp thất bại.";
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