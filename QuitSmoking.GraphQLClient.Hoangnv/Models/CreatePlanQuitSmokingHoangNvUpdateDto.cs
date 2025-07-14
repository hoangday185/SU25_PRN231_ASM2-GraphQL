using System;
using System.ComponentModel.DataAnnotations;

namespace QuitSmoking.GraphQLClient.HoangNV.Models
{
    public class CreatePlanQuitSmokingHoangNvUpdateDto
    {
        [Required]
        public int CreatePlanQuitSmokingHoangNvid { get; set; }
        [Required]
        public int UserAccountHoangNvid { get; set; }
        [Required]
        public string PlanTitle { get; set; } = null!;
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly TargetEndDate { get; set; }
        [Required]
        public int CurrentSmokingFrequency { get; set; }
        public int? DailyReductionGoal { get; set; }
        [Required]
        public string MotivationReason { get; set; } = null!;
        [Required]
        public string SelectedApproach { get; set; } = null!;
        public bool? IsActive { get; set; }
    }
} 