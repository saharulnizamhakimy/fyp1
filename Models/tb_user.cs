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
    
    public partial class tb_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_user()
        {
            this.tb_proposal = new HashSet<tb_proposal>();
        }
    
        public string u_ID { get; set; }
        public string u_pwd { get; set; }
        public string u_name { get; set; }
        public string u_contact { get; set; }
        public string u_email { get; set; }
        public int u_type { get; set; }
        public string u_acadProgID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_proposal> tb_proposal { get; set; }
        public virtual tb_student tb_student { get; set; }
        public virtual tb_sv tb_sv { get; set; }
        public virtual tb_usertype tb_usertype { get; set; }
        public virtual tb_acadprog tb_acadprog { get; set; }
    }
}
