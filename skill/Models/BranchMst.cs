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
    
    public partial class BranchMst
    {
        public int BranchId { get; set; }
        public Nullable<int> CityId { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<long> ModifyBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string IpAddress { get; set; }
        public string Host { get; set; }
    }
}
