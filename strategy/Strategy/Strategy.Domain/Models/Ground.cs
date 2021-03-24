using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Domain.Models
{
    abstract public class Ground : MapElement
    {
        public Ground(string name)
        {
            Name = name;
        }
      
    }
}
