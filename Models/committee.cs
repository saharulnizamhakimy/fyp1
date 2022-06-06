using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fyp1.Models
{
    [MetadataType(typeof(tb_committeeMetadata))]
    public partial class tb_committee
    {
        public class tb_committeeMetadata
        {
            [DisplayName("Committee ID")]
            public string cmt_ID { get; set; }

            [DisplayName("Program")]
            public string cmt_acadprogID { get; set; }
        }


    }
}