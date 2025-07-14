using Microsoft.AspNetCore.Components;
using QuitSmoking.GraphQLClient.HoangNV.Models;

namespace QuitSmoking.GraphQLClient.Hoangnv.CreatePlanHoangnv
{
    public partial class Update
    {
        [Parameter]
        public int Id { get; set; }
        private CreatePlanQuitSmokingHoangNvUpdateDto plan;
        private bool isLoading = true;
        private bool isUpdated = false;
        private string? errorMsg;
        private string redirectUrl = "/CreatePlanHoangnv/index";

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var result = await _graphQLConsumer.GetPlanById(Id);
                if (result != null)
                {
                    plan = new CreatePlanQuitSmokingHoangNvUpdateDto
                    {
                        CreatePlanQuitSmokingHoangNvid = result.CreatePlanQuitSmokingHoangNvid,
                        UserAccountHoangNvid = result.UserAccountHoangNvid,
                        PlanTitle = result.PlanTitle,
                        StartDate = result.StartDate,
                        TargetEndDate = result.TargetEndDate,
                        CurrentSmokingFrequency = result.CurrentSmokingFrequency,
                        DailyReductionGoal = result.DailyReductionGoal,
                        MotivationReason = result.MotivationReason,
                        SelectedApproach = result.SelectedApproach,
                        IsActive = result.IsActive
                    };
                }
                else
                {
                    plan = null;
                }
            }
            catch
            {
                plan = null;
            }
            isLoading = false;
        }

        private async Task HandleValidSubmit()
        {
            errorMsg = null;
            try
            {
                var dto = new QuitSmoking.GraphQLClient.HoangNV.Models.CreatePlanQuitSmokingHoangNvUpdateDto
                {
                    CreatePlanQuitSmokingHoangNvid = plan!.CreatePlanQuitSmokingHoangNvid,
                    UserAccountHoangNvid = plan.UserAccountHoangNvid,
                    PlanTitle = plan.PlanTitle,
                    StartDate = plan.StartDate,
                    TargetEndDate = plan.TargetEndDate,
                    CurrentSmokingFrequency = plan.CurrentSmokingFrequency,
                    DailyReductionGoal = plan.DailyReductionGoal,
                    MotivationReason = plan.MotivationReason,
                    SelectedApproach = plan.SelectedApproach,
                    IsActive = plan.IsActive
                };
                var result = await _graphQLConsumer.UpdatePlan(dto);
                if (result != null)
                {
                    isUpdated = true;
                }
                else
                {
                    errorMsg = "Cập nhật thất bại!";
                }
            }
            catch
            {
                errorMsg = "Có lỗi xảy ra khi cập nhật!";
            }
        }
    }
}