using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BOL
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:15,MinimumLength =3,ErrorMessage ="Length should be in between 3 to 15")]
        public string Title { get; set; }
        [Required]
        public string Info { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        [Range(minimum:1,maximum:100,ErrorMessage ="Quantity should not be zero")]
        public int Quantity { get; set; }

    }
}
