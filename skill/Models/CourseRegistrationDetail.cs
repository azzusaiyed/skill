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
    
    public partial class CourseRegistrationDetail
    {
        public int CourseRegistrationDetailId { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<int> RegistrationId { get; set; }
        public string Mode { get; set; }
        public string PaymentStatus { get; set; }
        public Nullable<decimal> TotalPaymentAmount { get; set; }
        public Nullable<decimal> PendingPaymentAmount { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<long> ModifyBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string IpAddress { get; set; }
        public string Host { get; set; }
    }
}
