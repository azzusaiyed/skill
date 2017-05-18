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
    using System.ComponentModel.DataAnnotations;

    public partial class CourseDocMapping
    {
        public int CourseDocMappingId { get; set; }
        [Required]
        public Nullable<int> CourseId { get; set; }
        [Required]
        public string DocTitle { get; set; }
        [Required]
        public string DocDetail { get; set; }
        public string FIleName { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<long> ModifyBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string IpAddress { get; set; }
    
        public virtual CourseDocMapping CourseDocMapping1 { get; set; }
        public virtual CourseDocMapping CourseDocMapping2 { get; set; }
        public virtual CourseMst CourseMst { get; set; }
    }
}
