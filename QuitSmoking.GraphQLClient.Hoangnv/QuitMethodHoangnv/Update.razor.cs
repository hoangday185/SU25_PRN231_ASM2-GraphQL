using Microsoft.AspNetCore.Components;
using QuitSmoking.GraphQLClient.Hoangnv.GraphQLClients;
using QuitSmoking.GraphQLClient.Hoangnv.Models;

namespace QuitSmoking.GraphQLClient.Hoangnv.QuitMethodHoangnv
{
    public partial class Update
    {
        [Parameter]
        public int id { get; set; }

        private QuitMethodHoangNv? method;
        private string redirectUrl = "/quitmethodhoangnv/index";


        protected override async Task OnInitializedAsync()
        {
            try
            {
                method = await _graphQLConsumer.GetQuitMethodById(id);
                if (method == null)
                {
                   
                }
            }
            catch (Exception ex)
            {
                
            }
            
        }

        private async Task HandleValidSubmit()
        {
           
            try
            {
                var result = await _graphQLConsumer.UpdateQuitMethod(method!);
                if (result != null && result.QuitMethodHoangNvid > 0)
                {
                    _navigationManager.NavigateTo(redirectUrl, true);
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
               
            }
            
        }
    }
}