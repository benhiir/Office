//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModelLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Job
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Job()
        {
            this.Userjobs = new HashSet<Userjob>();
            this.works = new HashSet<work>();
        }
    
        public int jobsID { get; set; }
        public string jobsName { get; set; }
        public string jobsDetail { get; set; }
        public Nullable<int> jobsLevel { get; set; }
        public Nullable<int> DetermineJobsLevel { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Userjob> Userjobs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<work> works { get; set; }
    }
}