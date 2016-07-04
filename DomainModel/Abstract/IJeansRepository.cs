using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Abstract
{
    public interface IJeansRepository
    {

        IEnumerable<Jeans> Jeans { get; }
    }
}
