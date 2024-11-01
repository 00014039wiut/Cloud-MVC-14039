using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSCC.CW1._14039.MVC.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Sport { get; set; }
        public string Division { get; set; }
        [ForeignKey("TeamCoach")]
        public Coach TeamCoach { get; set; }
    }
}