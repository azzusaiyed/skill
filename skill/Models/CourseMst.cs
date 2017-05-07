//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace skill.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourseMst
    {
        public int CourseId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> TrainerId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public string CourseName { get; set; }
        public string CourseAbb { get; set; }
        public string ShotDescription { get; set; }
        public string Overview { get; set; }
        public string Description { get; set; }
        public Nullable<int> OfflineSeat { get; set; }
        public Nullable<int> OnlineSeat { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<double> DurationInHours { get; set; }
        public Nullable<System.DateTime> ExtentionDate { get; set; }
        public Nullable<int> PendingOnlineSeat { get; set; }
        public Nullable<int> PendingOfflineSeat { get; set; }
        public Nullable<double> AvgRating { get; set; }
        public string CoursePDF { get; set; }
        public string CoursePhoto { get; set; }
        public string CourseVideoYouTubeLink { get; set; }
        public Nullable<int> CourseDocId { get; set; }
        public Nullable<decimal> CourseFee { get; set; }
        public Nullable<decimal> CourseInitialFee { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<long> ModifyBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string IpAddress { get; set; }
    }
}
