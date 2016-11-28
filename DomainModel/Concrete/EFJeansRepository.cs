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

        public void SaveProduct(Jeans jeans)
        {
            if (jeans.JeansId == 0)
            {
                context.Jeans.Add(jeans);
            }
            else
            {
                Jeans dbEntry = context.Jeans.Find(jeans.JeansId);
                if (dbEntry != null)
                {
                    dbEntry.Name = jeans.Name;                    
                    dbEntry.Price = jeans.Price;
                    dbEntry.Country = jeans.Country;
                    dbEntry.Sizes = jeans.Sizes;
                    dbEntry.Color = jeans.Color;
                   
                }
            }
            context.SaveChanges();
        }
    }
}
