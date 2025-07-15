using Microsoft.AspNetCore.Components;
using QuitSmoking.GraphQLClient.Hoangnv.Models;

namespace QuitSmoking.GraphQLClient.Hoangnv.PlanQuitHoangnv
{
    public partial class Update
    {

        [Parameter]
        public int Id { get; set; }

        [Parameter]
        [SupplyParameterFromQuery]
        public int CreateId { get; set; }

        public PlanQuitHoangnvUpdateDto planQuitMethod = new();
        private string redirectUrl = "/PlanQuitHoangnv/Index";
        private bool isLoading = true;
        private bool isUpdated = false;
        private string? errorMsg;
        
        protected override async Task OnInitializedAsync()
        {
            try
            {
                isLoading = true;

                var result = await _graphQLConsumer.GetPlanQuitMethodById(Id);
                planQuitMethod.PlanQuitMethodHoangNvid = result.PlanQuitMethodHoangNvid;
                planQuitMethod.IsSuccessful = result.IsSuccessful;
                planQuitMethod.CreatePlanQuitSmokingHoangNvid = CreateId;
                planQuitMethod.QuitMethodHoangNvid = result.QuitMethodHoangNvid;
                planQuitMethod.EndDate = result.EndDate;
                planQuitMethod.StartDate = result.StartDate;
                planQuitMethod.UserRating = result.UserRating;
                planQuitMethod.UserNotes = result.UserNotes;

            }
            catch
            {

            }
            finally
            {
                isLoading = false;
            }
        }

        public async Task HandleValidSubmit() 
        {
            try
            {
                isLoading = true;

                var result = await _graphQLConsumer.UpdatePlanQuitMethod(planQuitMethod);
                _navigationManager.NavigateTo($"{redirectUrl}/{CreateId}", true);

            }
            catch
            {

            }
            finally
            {
                isLoading = false;
            }
        }
    }
}