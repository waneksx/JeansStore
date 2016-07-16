using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class JeansQuantity
    {
        [Key]
        public int QuantityId { get; set; }

        [Required]
        public int Value { get; set; }
    }
}
