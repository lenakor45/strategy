using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Domain.Models
{
    abstract public class MapElement
    {
       public MapElement()
        {

        }
        /// <summary>
        /// Координата x
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Имя элемента
        /// </summary>
        public string Name { get; set; }
    }
}
