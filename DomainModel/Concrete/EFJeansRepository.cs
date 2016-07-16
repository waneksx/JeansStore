using DomainModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entities;

namespace DomainModel.Concrete
{
    public class EFJeansRepository : IJeansRepository
    {
        private JeansDbContext context = new JeansDbContext();
        public IEnumerable<Jeans> Jeans
        {
            get
            {
                return context.Jeans.Include("Color").Include("Country").Include("Sizes");
            }
        }
    }
}
