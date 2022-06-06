using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fyp1.Models
{
    [MetadataType(typeof(tb_usertypeMetadata))]
    public partial class tb_usertype
    {
        public class tb_usertypeMetadata
        {
            [Required]
            [DisplayName("User Type ID")]
            public string ut_ID { get; set; }

            [Required]
            [DisplayName("User Type")]
            public string ut_desc { get; set; }
        }


    }
}