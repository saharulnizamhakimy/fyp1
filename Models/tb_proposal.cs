//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fyp1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_proposal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_proposal()
        {
            this.tb_student = new HashSet<tb_student>();
        }
    
        public int p_ID { get; set; }
        public string p_studentID { get; set; }
        public Nullable<int> p_semester { get; set; }
        public string p_acadsession { get; set; }
        public string p_title { get; set; }
        public Nullable<int> p_domain { get; set; }
        public string p_detail { get; set; }
        public Nullable<int> p_status { get; set; }
        public string p_ev1ID { get; set; }
        public string p_ev2ID { get; set; }
        public string p_ev1comment { get; set; }
        public string p_ev2comment { get; set; }
        public string p_svcomment { get; set; }
    
        public virtual tb_domain tb_domain { get; set; }
        public virtual tb_status tb_status { get; set; }
        public virtual tb_user tb_user { get; set; }
        public virtual tb_user tb_user1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_student> tb_student { get; set; }
    }
}
