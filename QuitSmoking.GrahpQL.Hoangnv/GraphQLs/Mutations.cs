using Azure.Core;
using HotChocolate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuitSmoking.GrahpQL.Hoangnv.Models;
using QuitSmoking.Repositories.HoangNV.ModelExtentions;
using QuitSmoking.Repositories.HoangNV.Models;
using QuitSmoking.Services.HoangNV;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuitSmoking.GrahpQL.Hoangnv.GraphQLs
{
    public class Mutations
    {
        private readonly IServiceProviders _serviceProviders;
        private readonly IConfiguration _config;
        public Mutations(IServiceProviders serviceProviders, IConfiguration config)
        {

            _serviceProviders = serviceProviders;
            _config = config;
        }

        // Mutation để tạo kế hoạch bỏ thuốc mới
        public async Task<String> CreatePlan(CreatePlanQuitSmokingHoangNvCreateDto dto)
        {
            // Map DTO sang model
            var plan = new CreatePlanQuitSmokingHoangNv
            {
                UserAccountHoangNvid = dto.UserAccountHoangNvid,
                PlanTitle = dto.PlanTitle,
                StartDate = dto.StartDate,
                TargetEndDate = dto.TargetEndDate,
                CurrentSmokingFrequency = dto.CurrentSmokingFrequency,
                DailyReductionGoal = dto.DailyReductionGoal,
                MotivationReason = dto.MotivationReason,
                SelectedApproach = dto.SelectedApproach
            };
            await _serviceProviders.CreatePlanQuitSmokingHoangNvService.CreatePlanAsync(plan);
            return "Create plan success";
        }

        // Mutation để cập nhật kế hoạch bỏ thuốc
        public async Task<CreatePlanQuitSmokingHoangNv?> UpdatePlan(CreatePlanQuitSmokingHoangNvUpdateDto dto)
        {
            var plan = new CreatePlanQuitSmokingHoangNv
            {
                CreatePlanQuitSmokingHoangNvid = dto.CreatePlanQuitSmokingHoangNvid,
                UserAccountHoangNvid = dto.UserAccountHoangNvid,
                PlanTitle = dto.PlanTitle,
                StartDate = dto.StartDate,
                TargetEndDate = dto.TargetEndDate,
                CurrentSmokingFrequency = dto.CurrentSmokingFrequency,
                DailyReductionGoal = dto.DailyReductionGoal,
                MotivationReason = dto.MotivationReason,
                SelectedApproach = dto.SelectedApproach,
                IsActive = dto.IsActive
            };
            await _serviceProviders.CreatePlanQuitSmokingHoangNvService.UpdatePlanAsync(plan);
            return await _serviceProviders.CreatePlanQuitSmokingHoangNvService.GetPlanByIdAsync(plan.CreatePlanQuitSmokingHoangNvid);
        }

        // Mutation để xóa kế hoạch bỏ thuốc
        public async Task<bool> DeletePlan(int id)
        {
            var plan = await _serviceProviders.CreatePlanQuitSmokingHoangNvService.GetPlanByIdAsync(id);
            if (plan == null) return false;
            plan.IsActive = false;
            await _serviceProviders.CreatePlanQuitSmokingHoangNvService.UpdatePlanAsync(plan);
            return true;
        }

        // Mutation để tạo phương pháp bỏ thuốc mới
        public async Task<string> CreateQuitMethod(QuitMethodHoangNv method)
        {
             await _serviceProviders.QuitMethodHoangNvService.CreateMethodAsync(method);
            return "Create method success";
        }

        // Mutation để cập nhật phương pháp bỏ thuốc
        public async Task<QuitMethodHoangNv?> UpdateQuitMethod(QuitMethodHoangNv method)
        {
            var id = await _serviceProviders.QuitMethodHoangNvService.UpdateMethodAsync(method);
            return await _serviceProviders.QuitMethodHoangNvService.GetMethodByIdAsync(id);
        }

        // Mutation để xóa phương pháp bỏ thuốc
        public async Task<bool> DeleteQuitMethod(int id)
        {
            var method = await _serviceProviders.QuitMethodHoangNvService.GetMethodByIdAsync(id);
            method.IsActive = false;
             await _serviceProviders.QuitMethodHoangNvService.UpdateMethodAsync(method);
            return true;
        }

        // Mutation để tạo kế hoạch phương pháp mới
        public async Task<string> CreatePlanQuitMethod(PlanQuitMethodHoangNvCreateDto dto)
        {
            // Map DTO sang model
            var plan = new PlanQuitMethodHoangNv
            {
                CreatePlanQuitSmokingHoangNvid = dto.CreatePlanQuitSmokingHoangNvid,
                QuitMethodHoangNvid = dto.QuitMethodHoangNvid,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsSuccessful = false,
                UserRating = dto.UserRating,
                UserNotes = dto.UserNotes,
            };
             await _serviceProviders.PlanQuitHoangNvService.CreatePlanAsync(plan);
            return "Create plan method success";
        }

        // Mutation để cập nhật kế hoạch phương pháp
        public async Task<PlanQuitMethodHoangNv?> UpdatePlanQuitMethod(PlanQuitHoangnvUpdateDto dto)
        {
            // Lấy entity gốc từ DB
            var planMethod = await _serviceProviders.PlanQuitHoangNvService.GetPlanByIdAsync(dto.PlanQuitMethodHoangNvid);
            if (planMethod == null) return null;

            // Map các trường từ DTO sang entity
            planMethod.CreatePlanQuitSmokingHoangNvid = dto.CreatePlanQuitSmokingHoangNvid;
            planMethod.QuitMethodHoangNvid = dto.QuitMethodHoangNvid;
            planMethod.StartDate = dto.StartDate;
            planMethod.EndDate = dto.EndDate;
            planMethod.IsSuccessful = dto.IsSuccessful;
            planMethod.UserRating = dto.UserRating;
            planMethod.UserNotes = dto.UserNotes;

            // Gọi update
            await _serviceProviders.PlanQuitHoangNvService.UpdatePlanAsync(planMethod);
            return await _serviceProviders.PlanQuitHoangNvService.GetPlanByIdAsync(planMethod.PlanQuitMethodHoangNvid);
        }

        // Mutation để xóa kế hoạch phương pháp
        public async Task<bool> DeletePlanQuitMethod(int id)
        {
         
            return await _serviceProviders.PlanQuitHoangNvService.DeletePlanAsync(id);
        }

        // Mutation login
        public async Task<LoginResult> Login(string username, string password)
        {
            var userService = new UserService();
            var user = await userService.loginAsync(username, password);

            if (user == null)
            {
                return new LoginResult
                {
                    Success = false,
                    Error = "Unauthorized"
                };
            }

            var token = GenerateJSONWebToken(user);
            return new LoginResult
            {
                Success = true,
                Token = token
            };
        }

        private string GenerateJSONWebToken(UserAccountHoangNv systemUserAccount)
        {
           
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"]
                    , _config["Jwt:Audience"]
                    , new Claim[]
                    {
                new(ClaimTypes.Name, systemUserAccount.UserName),
                //new(ClaimTypes.Email, systemUserAccount.Email),
                new(ClaimTypes.Role, systemUserAccount.RoleId.ToString()),
                new(ClaimTypes.NameIdentifier, systemUserAccount.UserAccountHoangNvid.ToString()),
                    },
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
