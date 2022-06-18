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

            
            [DisplayName("Status")]
            public Nullable<int> p_status { get; set; }

            [DisplayName("Evaluator 1 ID")]
            public string p_ev1ID { get; set; }

            [DisplayName("Evaluator 2 ID")]
            public string p_ev2ID { get; set; }

            [DisplayName("Evaluator 1 Comment")]
            public string p_ev1comment { get; set; }

            [DisplayName("Evaluator 2 Comment")]
            public string p_ev2comment { get; set; }

            [DisplayName("Supervisor Comment")]
            public string p_svcomment { get; set; }

            [DataType(DataType.MultilineText)]
            [DisplayName("Problem Background & Solution")]
            public string p_bgNsol { get; set; }

            [DataType(DataType.MultilineText)]
            [DisplayName("Objective")]
            public string p_obj { get; set; }

            [DataType(DataType.MultilineText)]
            [DisplayName("Scope")]
            public string p_scope { get; set; }

            [DataType(DataType.MultilineText)]
            [DisplayName("Software Requirement")]
            public string p_softreq { get; set; }

            [DataType(DataType.MultilineText)]
            [DisplayName("Hardware Requirement")]
            public string p_hardreq { get; set; }


            [DataType(DataType.MultilineText)]
            [DisplayName("Technical Requirement")]
            public string p_techreq { get; set; }


            [DataType(DataType.MultilineText)]
            [DisplayName("Network Requirement")]
            public string p_netreq { get; set; }


            [DataType(DataType.MultilineText)]
            [DisplayName("Security Requirement")]
            public string p_secreq { get; set; }

            [DataType(DataType.MultilineText)]
            [DisplayName("Area")]
            public string p_area { get; set; }

            [Required]
            [DisplayName("Idea")]
            public string p_idea { get; set; }
        }


    }
}