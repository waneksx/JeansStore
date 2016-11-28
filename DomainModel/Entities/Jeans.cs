using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DomainModel.Entities
{
    public class Jeans
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int JeansId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public virtual ICollection<Size> Sizes { get; set; }

        [Column("ColorId")]
        public virtual Color Color { get; set; }
        

        public virtual Country Country { get; set; }


        //public void SellOne(int jeansId, int size)


    }
}
