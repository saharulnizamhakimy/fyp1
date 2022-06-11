using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fyp1.Models
{
    [MetadataType(typeof(tb_userMetadata))]
    public partial class tb_user
    {
        public class tb_userMetadata
        {
            [Required]
            [DisplayName("User ID")]
            public string u_ID { get; set; }

            [Required]
            [DisplayName("Password")]
            public string u_pwd { get; set; }

            [Required]
            [DisplayName("Name")]
            public string u_name { get; set; }

            [DisplayName("Contact Number")]
            public string u_contact { get; set; }

            [Required]
            [DisplayName("Email")]
            [DataType(DataType.EmailAddress)]
            public string u_email { get; set; }

            [DisplayName("User Type")]
            public int u_type { get; set; }
        }


    }
}