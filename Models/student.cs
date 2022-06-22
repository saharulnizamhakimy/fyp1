using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fyp1.Models
{
    [MetadataType(typeof(tb_studentMetadata))]
    public partial class tb_student
    {
        public class tb_studentMetadata
        {
            [Required]
            [DisplayName("Student ID")]
            public string s_id { get; set; }

            [DisplayName("Supervisor")]
            public string s_svID { get; set; }

            [DisplayName("Supervisor Status")]
            public Nullable<int> s_svstatus { get; set; }
        }


    }
}