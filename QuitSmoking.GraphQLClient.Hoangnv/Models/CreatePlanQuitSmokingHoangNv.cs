using QuitSmoking.GraphQLClient.Hoangnv.Models;
using System;
using System.Collections.Generic;


namespace QuitSmoking.GraphQLClient.HoangNV.Models;

public partial class CreatePlanQuitSmokingHoangNv
{
    public int CreatePlanQuitSmokingHoangNvid { get; set; }

    public int UserAccountHoangNvid { get; set; }

    public string PlanTitle { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly TargetEndDate { get; set; }

    public int CurrentSmokingFrequency { get; set; }

    public int? DailyReductionGoal { get; set; }

    public string MotivationReason { get; set; } = null!;

    public string SelectedApproach { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreationDateTime { get; set; }

    public virtual List<PlanQuitMethodHoangNv> PlanQuitMethodHoangNvs { get; set; } = new List<PlanQuitMethodHoangNv>();

    public virtual List<RecordProcessHoangNv> RecordProcessHoangNvs { get; set; } = new List<RecordProcessHoangNv>();

    public virtual UserAccountHoangNv UserAccountHoangNv { get; set; } = null!;
}

