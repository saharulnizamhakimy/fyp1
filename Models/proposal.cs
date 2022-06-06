using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fyp1.Models
{
    [MetadataType(typeof(tb_proposalMetadata))]
    public partial class tb_proposal
    {
        public class tb_proposalMetadata
        {
            [DisplayName("Proposal ID")]
            public int p_ID { get; set; }
            
            [Required]
            [DisplayName("Student ID")]
            public string p_studentID { get; set; }

            [Required]
            [DisplayName("Semester")]
            public Nullable<int> p_semester { get; set; }

            [Required]
            [DisplayName("Session")]
            public string p_acadsession { get; set; }

            [Required]
            [DisplayName("Title")]
            public string p_title { get; set; }

            [Required]
            [DisplayName("Domain")]
            public Nullable<int> p_domain { get; set; }

            [Required]
            [DisplayName("Details")]
            public string p_detail { get; set; }

            [Required]
            [DisplayName("Status")]
            public Nullable<int> p_status { get; set; }

            [Required]
            [DisplayName("Evaluator 1 ID")]
            public string p_ev1ID { get; set; }

            [Required]
            [DisplayName("Evaluator 2 ID")]
            public string p_ev2ID { get; set; }

            [Required]
            [DisplayName("Evaluator 2 Comment")]
            public string p_ev1comment { get; set; }

            [Required]
            [DisplayName("Evaluator 2 Comment")]
            public string p_ev2comment { get; set; }

            [Required]
            [DisplayName("Supervisor Comment")]
            public string p_svcomment { get; set; }
        }


    }
}