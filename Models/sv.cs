using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fyp1.Models
{
    [MetadataType(typeof(tb_svMetadata))]
    public partial class tb_sv
    {
        public class tb_svMetadata
        {
            [DisplayName("Supervisor ID")]
            public string sv_ID { get; set; }

            [DisplayName("Supervisor's Domain")]
            public Nullable<int> sv_domainID { get; set; }
        }


    }
}