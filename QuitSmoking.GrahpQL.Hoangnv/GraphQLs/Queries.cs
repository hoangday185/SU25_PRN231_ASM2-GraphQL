using QuitSmoking.Services.HoangNV;
using QuitSmoking.Repositories.HoangNV.Models;
using QuitSmoking.Repositories.HoangNV.ModelExtentions;
using HotChocolate;

namespace QuitSmoking.GrahpQL.Hoangnv.GraphQLs
{
    public class Queries
    {
        private readonly IServiceProviders _serviceProviders;
        public Queries(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }

        // Query để lấy tất cả kế hoạch bỏ thuốc
        public async Task<List<CreatePlanQuitSmokingHoangNv>> GetAllPlans()
        {
            return await _serviceProviders.CreatePlanQuitSmokingHoangNvService.GetAllPlansAsync();
        }

        // Query để lấy kế hoạch theo ID
        public async Task<CreatePlanQuitSmokingHoangNv?> GetPlanById(int id)
        {
            return await _serviceProviders.CreatePlanQuitSmokingHoangNvService.GetPlanByIdAsync(id);
        }

        // Query để lấy kế hoạch có phân trang
        public async Task<PaginationResult<CreatePlanQuitSmokingHoangNv>> GetPlansWithPagination(
            int page = 1, 
            int pageSize = 10, 
            string? planTitle = null, 
            bool? isActive = null)
        {
            return await _serviceProviders.CreatePlanQuitSmokingHoangNvService.GetPaginatedPlansAsync(page, pageSize, planTitle, isActive);
        }

        // Query để tìm kiếm kế hoạch theo tiêu đề
        public async Task<List<CreatePlanQuitSmokingHoangNv>> SearchPlans(string title)
        {
            return await _serviceProviders.CreatePlanQuitSmokingHoangNvService.SearchAsync(title);
        }

        // Query để lấy tất cả phương pháp bỏ thuốc
        public async Task<List<QuitMethodHoangNv>> GetAllQuitMethods(bool isActive = true)
        {
            return await _serviceProviders.QuitMethodHoangNvService.GetListQuitMethodAsync(isActive);
        }

        // Query để lấy phương pháp bỏ thuốc theo ID
        public async Task<QuitMethodHoangNv?> GetQuitMethodById(int id)
        {
            return await _serviceProviders.QuitMethodHoangNvService.GetMethodByIdAsync(id);
        }

        // Query để lấy phương pháp bỏ thuốc có phân trang
        public async Task<PaginationResult<QuitMethodHoangNv>> GetQuitMethodsWithPagination(
            int page = 1, 
            int pageSize = 10, 
            string? search = null)
        {
            return await _serviceProviders.QuitMethodHoangNvService.getMethodWithPaginationAsync(page, pageSize, search);
        }

        // Query để lấy tất cả kế hoạch phương pháp
        public async Task<List<PlanQuitMethodHoangNv>> GetAllPlanQuitMethods()
        {
            return await _serviceProviders.PlanQuitHoangNvService.GetAllPlansAsync();
        }

        // Query để lấy kế hoạch phương pháp theo ID
        public async Task<PlanQuitMethodHoangNv?> GetPlanQuitMethodById(int id)
        {
            return await _serviceProviders.PlanQuitHoangNvService.GetPlanByIdAsync(id);
        }

        // Query để lấy kế hoạch phương pháp có phân trang
        public async Task<PaginationResult<PlanQuitMethodHoangNv>> GetPlanQuitMethodsWithPagination(
            int page = 1, 
            int pageSize = 10, 
            int? createPlanId = null, 
            string? search = null)
        {
            return await _serviceProviders.PlanQuitHoangNvService.GetPaginatedPlansAsync(page, pageSize, createPlanId, search);
        }
    }
}
