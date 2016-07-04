using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class JeansListViewModel
    {
        public IEnumerable<Jeans> Jeans { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentColor { get; set; }
    }
}