using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WorkshopManagementApp.Models
{
    [Table("workshop")]
    public class Workshop
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Topic { get; set; }
       public string Description { get; set; }
        [Required]
        public string Presentor { get; set; }
        [Required]
        public string Location { get; set; }

    }
}