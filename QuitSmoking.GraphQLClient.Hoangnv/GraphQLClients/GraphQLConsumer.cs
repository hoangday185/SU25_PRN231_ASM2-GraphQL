using GraphQL;
using GraphQL.Client.Abstractions;
using QuitSmoking.GraphQLClient.Hoangnv.Models;
using QuitSmoking.GraphQLClient.HoangNV.Models;
using QuitSmoking.Repositories.HoangNV.ModelExtentions;


namespace QuitSmoking.GraphQLClient.Hoangnv.GraphQLClients
{
    public class GraphQLConsumer
    {
        private readonly IGraphQLClient _graphQLClient;

        public GraphQLConsumer(IGraphQLClient graphQLClient) => _graphQLClient = graphQLClient;

        // Lấy danh sách kế hoạch bỏ thuốc
        public async Task<List<CreatePlanQuitSmokingHoangNv>> GetAllPlans()
        {
            var query = @"
                query {
                    allPlans {
                        createPlanQuitSmokingHoangNvid
                        userAccountHoangNvid
                        planTitle
                        startDate
                        targetEndDate
                        currentSmokingFrequency
                        dailyReductionGoal
                        motivationReason
                        selectedApproach
                        isActive
                        creationDateTime
                    }
                }";
            var response = await _graphQLClient.SendQueryAsync<GetAllPlansResponse>(query);
            return response.Data?.allPlans ?? new List<CreatePlanQuitSmokingHoangNv>();
        }

        public class GetAllPlansResponse
        {
            public List<CreatePlanQuitSmokingHoangNv> allPlans { get; set; }
        }

        // Đăng nhập, trả về token nếu thành công
        public async Task<string?> Login(string username, string password)
        {
            var mutation = @"
                mutation($username: String!, $password: String!) {
                    login(username: $username, password: $password) {
                        success
                        token
                        error
                    }
                }";
            var request = new GraphQLRequest
            {
                Query = mutation,
                Variables = new { username, password }
            };
            var response = await _graphQLClient.SendMutationAsync<LoginResponse>(request);
            return response.Data?.login?.success == true ? response.Data.login.token : null;
        }

        public class LoginResponse
        {
            public LoginResult login { get; set; }
        }
        public class LoginResult
        {
            public bool success { get; set; }
            public string token { get; set; }
            public string error { get; set; }
        }

        public async Task<string?> CreatePlan(CreatePlanQuitSmokingHoangNvCreateDto dto)
        {
            var mutation = @"
                mutation($dto: CreatePlanQuitSmokingHoangNvCreateDtoInput!) {
                    createPlan(dto: $dto)
                }
            ";
            var request = new GraphQLRequest
            {
                Query = mutation,
                Variables = new { dto }
            };
            var response = await _graphQLClient.SendMutationAsync<CreatePlanResponse>(request);
            return response.Data?.createPlan;
        }

        public class CreatePlanResponse
        {
            public string createPlan { get; set; }
        }

        // Update kế hoạch bỏ thuốc
        public async Task<CreatePlanQuitSmokingHoangNv?> UpdatePlan(CreatePlanQuitSmokingHoangNvUpdateDto dto)
        {
            var mutation = @"
                mutation($dto: CreatePlanQuitSmokingHoangNvUpdateDtoInput!) {
                    updatePlan(dto: $dto) {
                        createPlanQuitSmokingHoangNvid
                        userAccountHoangNvid
                        planTitle
                        startDate
                        targetEndDate
                        currentSmokingFrequency
                        dailyReductionGoal
                        motivationReason
                        selectedApproach
                        isActive
                        creationDateTime
                    }
                }
            ";
            var request = new GraphQLRequest
            {
                Query = mutation,
                Variables = new { dto }
            };
            var response = await _graphQLClient.SendMutationAsync<UpdatePlanResponse>(request);
            return response.Data?.updatePlan;
        }
        public class UpdatePlanResponse { public CreatePlanQuitSmokingHoangNv updatePlan { get; set; } }

        // Xóa kế hoạch bỏ thuốc
        public async Task<bool> DeletePlan(int id)
        {
            var mutation = @"
                mutation($id: Int!) {
                    deletePlan(id: $id)
                }
            ";
            var request = new GraphQLRequest
            {
                Query = mutation,
                Variables = new { id }
            };
            var response = await _graphQLClient.SendMutationAsync<DeletePlanResponse>(request);
            return response.Data?.deletePlan ?? false;
        }
        public class DeletePlanResponse { public bool deletePlan { get; set; } }

        // Lấy kế hoạch theo ID
        public async Task<CreatePlanQuitSmokingHoangNv?> GetPlanById(int id)
        {
            var query = @"
                query($id: Int!) {
                    planById(id: $id) {
                        createPlanQuitSmokingHoangNvid
                        userAccountHoangNvid
                        planTitle
                        startDate
                        targetEndDate
                        currentSmokingFrequency
                        dailyReductionGoal
                        motivationReason
                        selectedApproach
                        isActive
                        creationDateTime
                    }
                }
            ";
            var request = new GraphQLRequest
            {
                Query = query,
                Variables = new { id }
            };
            var response = await _graphQLClient.SendQueryAsync<GetPlanByIdResponse>(request);
            return response.Data?.planById;
        }
        public class GetPlanByIdResponse { public CreatePlanQuitSmokingHoangNv planById { get; set; } }

        // Tìm kiếm kế hoạch theo tiêu đề
        public async Task<List<CreatePlanQuitSmokingHoangNv>> SearchPlans(string title)
        {
            var query = @"
                query($title: String!) {
                    searchPlans(title: $title) {
                        createPlanQuitSmokingHoangNvid
                        userAccountHoangNvid
                        planTitle
                        startDate
                        targetEndDate
                        currentSmokingFrequency
                        dailyReductionGoal
                        motivationReason
                        selectedApproach
                        isActive
                        creationDateTime
                    }
                }
            ";
            var request = new GraphQLRequest
            {
                Query = query,
                Variables = new { title }
            };
            var response = await _graphQLClient.SendQueryAsync<SearchPlansResponse>(request);
            return response.Data?.searchPlans ?? new List<CreatePlanQuitSmokingHoangNv>();
        }
        public class SearchPlansResponse { public List<CreatePlanQuitSmokingHoangNv> searchPlans { get; set; } }

        // Lấy tất cả phương pháp bỏ thuốc
        public async Task<List<QuitMethodHoangNv>> GetAllQuitMethods(bool isActive = true)
        {
            var query = @"
                query($isActive: Boolean!) {
                    allQuitMethods(isActive: $isActive) {
                        quitMethodHoangNvid
                        methodName
                        methodDescription
                        effectivenessRating
                        difficultyLevel
                        recommendedDuration
                        requiresMedical
                        requiresCounseling
                        isPopular
                        creationDateTime
                        isActive
                    }
                }
            ";
            var request = new GraphQLRequest
            {
                Query = query,
                Variables = new { isActive }
            };
            var response = await _graphQLClient.SendQueryAsync<GetAllQuitMethodsResponse>(request);
            return response.Data?.allQuitMethods ?? new List<QuitMethodHoangNv>();
        }
        public class GetAllQuitMethodsResponse { public List<QuitMethodHoangNv> allQuitMethods { get; set; } }

        // Lấy phương pháp bỏ thuốc theo ID
        public async Task<QuitMethodHoangNv?> GetQuitMethodById(int id)
        {
            var query = @"
                query($id: Int!) {
                    quitMethodById(id: $id) {
                        quitMethodHoangNvid
                        methodName
                        methodDescription
                        effectivenessRating
                        difficultyLevel
                        recommendedDuration
                        requiresMedical
                        requiresCounseling
                        isPopular
                        creationDateTime
                        isActive
                    }
                }
            ";
            var request = new GraphQLRequest
            {
                Query = query,
                Variables = new { id }
            };
            var response = await _graphQLClient.SendQueryAsync<GetQuitMethodByIdResponse>(request);
            return response.Data?.quitMethodById;
        }
        public class GetQuitMethodByIdResponse { public QuitMethodHoangNv quitMethodById { get; set; } }

        // Tạo phương pháp bỏ thuốc mới
        public async Task<QuitMethodHoangNv?> CreateQuitMethod(QuitMethodHoangNv method)
        {
            var mutation = @"
                mutation($method: QuitMethodHoangNvInput!) {
                    createQuitMethod(method: $method) {
                        quitMethodHoangNvid
                        methodName
                        methodDescription
                        effectivenessRating
                        difficultyLevel
                        recommendedDuration
                        requiresMedical
                        requiresCounseling
                        isPopular
                        creationDateTime
                        isActive
                    }
                }
            ";
            var request = new GraphQLRequest
            {
                Query = mutation,
                Variables = new { method }
            };
            var response = await _graphQLClient.SendMutationAsync<CreateQuitMethodResponse>(request);
            return response.Data?.createQuitMethod;
        }
        public class CreateQuitMethodResponse { public QuitMethodHoangNv createQuitMethod { get; set; } }

        // Cập nhật phương pháp bỏ thuốc
        public async Task<QuitMethodHoangNv?> UpdateQuitMethod(QuitMethodHoangNv method)
        {
            var mutation = @"
                mutation($method: QuitMethodHoangNvInput!) {
                    updateQuitMethod(method: $method) {
                        quitMethodHoangNvid
                        methodName
                        methodDescription
                        effectivenessRating
                        difficultyLevel
                        recommendedDuration
                        requiresMedical
                        requiresCounseling
                        isPopular
                        creationDateTime
                        isActive
                    }
                }
            ";
            var request = new GraphQLRequest
            {
                Query = mutation,
                Variables = new { method }
            };
            var response = await _graphQLClient.SendMutationAsync<UpdateQuitMethodResponse>(request);
            return response.Data?.updateQuitMethod;
        }
        public class UpdateQuitMethodResponse { public QuitMethodHoangNv updateQuitMethod { get; set; } }

        // Xóa phương pháp bỏ thuốc
        public async Task<bool> DeleteQuitMethod(int id)
        {
            var mutation = @"
                mutation($id: Int!) {
                    deleteQuitMethod(id: $id)
                }
            ";
            var request = new GraphQLRequest
            {
                Query = mutation,
                Variables = new { id }
            };
            var response = await _graphQLClient.SendMutationAsync<DeleteQuitMethodResponse>(request);
            return response.Data?.deleteQuitMethod ?? false;
        }
        public class DeleteQuitMethodResponse { public bool deleteQuitMethod { get; set; } }

        public async Task<List<PlanQuitMethodHoangNv>> GetAllPlanQuitMethods()
        {
            var query = @"
                query {
                    allPlanQuitMethods {
                        planQuitMethodHoangNvid
                        userAccountHoangNvid
                        planTitle
                        startDate
                        targetEndDate
                        currentSmokingFrequency
                        dailyReductionGoal
                        motivationReason
                        selectedApproach
                        isActive
                        creationDateTime
                    }
                }";
            var response = await _graphQLClient.SendQueryAsync<GetAllPlanQuitMethodsResponse>(query);
            return response.Data?.allPlanQuitMethods ?? new List<PlanQuitMethodHoangNv>();
        }

        public class GetAllPlanQuitMethodsResponse
        {
            public List<PlanQuitMethodHoangNv> allPlanQuitMethods { get; set; }
        }

        public async Task<PlanQuitMethodHoangNv> GetPlanQuitMethodById(int id)
        {
            var query = @"
                query($id: Int!) {
                    planQuitMethodById(id: $id) {
                        planQuitMethodHoangNvid
                        userAccountHoangNvid
                        planTitle
                        startDate
                        targetEndDate
                        currentSmokingFrequency
                        dailyReductionGoal
                        motivationReason
                        selectedApproach
                        isActive
                        creationDateTime
                    }
                }";
            var request = new GraphQLRequest
            {
                Query = query,
                Variables = new { id }
            };
            var response = await _graphQLClient.SendQueryAsync<GetPlanQuitMethodByIdResponse>(request);
            return response.Data?.planQuitMethodById;
        }

        public class GetPlanQuitMethodByIdResponse
        {
            public PlanQuitMethodHoangNv planQuitMethodById { get; set; }
        }

        public async Task<PlanQuitMethodHoangNv> CreatePlanQuitMethod(PlanQuitMethodHoangNv method)
        {
            var mutation = @"
                mutation($method: PlanQuitMethodHoangNvInput!) {
                    createPlanQuitMethod(method: $method) {
                        planQuitMethodHoangNvid
                        userAccountHoangNvid
                        planTitle
                        startDate
                        targetEndDate
                        currentSmokingFrequency
                        dailyReductionGoal
                        motivationReason
                        selectedApproach
                        isActive
                        creationDateTime
                    }
                }";
            var request = new GraphQLRequest
            {
                Query = mutation,
                Variables = new { method }
            };
            var response = await _graphQLClient.SendMutationAsync<CreatePlanQuitMethodResponse>(request);
            return response.Data?.createPlanQuitMethod;
        }

        public class CreatePlanQuitMethodResponse
        {
            public PlanQuitMethodHoangNv createPlanQuitMethod { get; set; }
        }

        public async Task<PlanQuitMethodHoangNv> UpdatePlanQuitMethod(PlanQuitMethodHoangNv method)
        {
            var mutation = @"
                mutation($method: PlanQuitMethodHoangNvInput!) {
                    updatePlanQuitMethod(method: $method) {
                        planQuitMethodHoangNvid
                        userAccountHoangNvid
                        planTitle
                        startDate
                        targetEndDate
                        currentSmokingFrequency
                        dailyReductionGoal
                        motivationReason
                        selectedApproach
                        isActive
                        creationDateTime
                    }
                }";
            var request = new GraphQLRequest
            {
                Query = mutation,
                Variables = new { method }
            };
            var response = await _graphQLClient.SendMutationAsync<UpdatePlanQuitMethodResponse>(request);
            return response.Data?.updatePlanQuitMethod;
        }

        public class UpdatePlanQuitMethodResponse
        {
            public PlanQuitMethodHoangNv updatePlanQuitMethod { get; set; }
        }

        public async Task<bool> DeletePlanQuitMethod(int id)
        {
            var mutation = @"
                mutation($id: Int!) {
                    deletePlanQuitMethod(id: $id)
                }";
            var request = new GraphQLRequest
            {
                Query = mutation,
                Variables = new { id }
            };
            var response = await _graphQLClient.SendMutationAsync<DeletePlanQuitMethodResponse>(request);
            return response.Data?.deletePlanQuitMethod ?? false;
        }

        public class DeletePlanQuitMethodResponse
        {
            public bool deletePlanQuitMethod { get; set; }
        }

    }
}
