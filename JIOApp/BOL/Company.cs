using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class Company
    {
        [Required]
        [Range(minimum:1,maximum:100,ErrorMessage ="Number should be between 1 to 100")]
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyContactNo { get; set; }
        [Required]
        public string CompanyProduct { get; set; }
    }
}
