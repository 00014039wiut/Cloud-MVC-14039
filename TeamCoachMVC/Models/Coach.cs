using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSCC.CW1._14039.MVC.Models
{
    public class Coach
    {
        public int CoachId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public int ExperienceYears { get; set; }
    }
}