using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fyp1.Models
{
    [MetadataType(typeof(tb_domainMetadata))]
    public partial class tb_domain
    {
        public class tb_domainMetadata
        {
            [DisplayName("Domain ID")]
            public int d_ID { get; set; }

            [DisplayName("Domain")]
            public string d_desc { get; set; }
        }


    }
}