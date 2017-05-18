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

    public partial class BranchMst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BranchMst()
        {
            this.CourseMsts = new HashSet<CourseMst>();
            this.UserMsts = new HashSet<UserMst>();
        }
    
        public int BranchId { get; set; }

        [Required(ErrorMessage = "City Name field is required.")]
        public Nullable<int> CityId { get; set; }

        [Required]
        [Display(Name ="Branch Name")]
        public string BranchName { get; set; }

        [Required]
        [Display(Name = "Branch Address")]
        public string BranchAddress { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string EmailId { get; set; }

        [Required]
        [Display(Name = "Mobile")]
        //[RegularExpression(@"^([0]|\+91[\-\s]?)?[789]\d{9}$", ErrorMessage = "Entered Mobile No is not valid.")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid mobile no.")]
        public string MobileNo { get; set; }

        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<long> ModifyBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [Display(Name = "Ip Address")]
        public string IpAddress { get; set; }
        public string Host { get; set; }
    
        public virtual CityMst CityMst { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseMst> CourseMsts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserMst> UserMsts { get; set; }
    }
}
