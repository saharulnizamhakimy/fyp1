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
    
    public partial class tb_student
    {
        public string s_id { get; set; }
        public string s_acadprogID { get; set; }
        public string s_svID { get; set; }
        public Nullable<int> s_proposalD { get; set; }
    
        public virtual tb_acadprog tb_acadprog { get; set; }
        public virtual tb_proposal tb_proposal { get; set; }
        public virtual tb_sv tb_sv { get; set; }
        public virtual tb_user tb_user { get; set; }
    }
}
