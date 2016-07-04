using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(Jeans jeans, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Jeans.JeansId == jeans.JeansId)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Jeans = jeans,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Jeans jeans)
        {
            lineCollection.RemoveAll(l => l.Jeans.JeansId == jeans.JeansId);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Jeans.Price * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
}
