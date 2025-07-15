namespace QuitSmoking.GrahpQL.Hoangnv.Models
{
    public class PlanQuitHoangnvUpdateDto
    {
        public int PlanQuitMethodHoangNvid { get; set; }

        public int CreatePlanQuitSmokingHoangNvid { get; set; }

        public int QuitMethodHoangNvid { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public bool? IsSuccessful { get; set; }

        public int? UserRating { get; set; }

        public string? UserNotes { get; set; }
    }
}
