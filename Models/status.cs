using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fyp1.Models
{
    [MetadataType(typeof(tb_statusMetadata))]
    public partial class tb_status
    {
        public class tb_statusMetadata
        {
            [DisplayName("Status ID")]
            public int st_ID { get; set; }

            [DisplayName("Status")]
            public string st_desc { get; set; }
        }


    }
}