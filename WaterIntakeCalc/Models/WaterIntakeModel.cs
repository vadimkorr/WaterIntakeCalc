using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WaterIntakeCalc.Models
{
    [Table("WaterIntakes")]
    public class WaterIntakeModel
    {
        public WaterIntakeModel() { }
        [Key]
        public int WaterIntakeId { get; set; }
        public int WaterAmount { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}