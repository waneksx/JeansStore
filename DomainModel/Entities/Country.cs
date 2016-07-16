using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }


        [Required]
        public string Name { get; set; }
    }
}
