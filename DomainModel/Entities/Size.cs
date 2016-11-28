using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Size
    {
        [Key]
        public int SizeId { get; set; }

        [Required]
        public int SizeValue { get; set; }


        [Required]
        public int Quantity { get; set; }

    }
}
