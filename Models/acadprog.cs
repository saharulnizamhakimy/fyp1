using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fyp1.Models
{
    [MetadataType(typeof(tb_acadprogMetadata))]
    public partial class tb_acadprog
    {
        public class tb_acadprogMetadata
        {
            [DisplayName("Academic Program ID")]
            public string ap_ID { get; set; }

            [DisplayName("Academic Program")]
            public string ap_desc { get; set; }
        }


    }
}