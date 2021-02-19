using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Domain.Models
{
    public class Unit
    {
        public Unit(Player player, int hp, int step, int attac, int damage)
        {
            Player = player;
            Hp = hp;
            Step = step;
            Attac = attac;
            Damage = damage;
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
        /// <summary>
        /// Шаг юнита.
        /// </summary>
        public int Step { get; set; }
        /// <summary>
        /// Дальность атаки юнита.
        /// </summary>
        public int Attac { get; set; }
        /// <summary>
        /// Размер наносимого юнитом урона.
        /// </summary>
        public int Damage { get; set; }
        
    }
}
