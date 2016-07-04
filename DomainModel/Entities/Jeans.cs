using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Jeans
    {
        [Key]       
        public int JeansId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Color { get; set; }

        //public Color JeansColor { get; set; }

        public string Country { get ; set; }

        
    }
}
