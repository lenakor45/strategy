using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Domain.Models
{
    public class Unit
    {
        public Unit(Player player, int hp)
        {
            Player = player;
            Hp = hp;
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
        /// Игрок, который управляет юнитом.
        /// </summary>
        public Player Player { get; }

        /// <summary>
        /// Уровень здоровья юнита.
        /// </summary>
        public int Hp { get; set; }
    }
}
