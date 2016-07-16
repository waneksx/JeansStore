using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }


        [Required]
        public string Name { get; set; }

        public string HtmlCode { get; set; }
    }
}
