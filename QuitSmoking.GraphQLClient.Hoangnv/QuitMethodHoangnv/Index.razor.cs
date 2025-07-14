namespace QuitSmoking.GraphQLClient.Hoangnv.QuitMethodHoangnv
{
    public partial class Index
    {
        private List<QuitSmoking.GraphQLClient.Hoangnv.Models.QuitMethodHoangNv>? quitMethods;
        private bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            isLoading = true;
            quitMethods = await _graphQLConsumer.GetAllQuitMethods();
            isLoading = false;
        }

        private void CreateMethod()
        {
            _navigationManager.NavigateTo("/QuitMethodHoangnv/create");
        }

        private void EditMethod(int id)
        {
            _navigationManager.NavigateTo($"/QuitMethodHoangnv/update/{id}");
        }

        private void DeleteMethod(int id)
        {
            _navigationManager.NavigateTo($"/QuitMethodHoangnv/delete/{id}");
        }
    }
}