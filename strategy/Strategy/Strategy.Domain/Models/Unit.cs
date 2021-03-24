using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Domain.Models
{
    abstract public class Unit :MapElement
    {
        public Unit(Player player, int hp, int step, int attac, int damage, string name, bool isChangeDamage)
        {
            Player = player;
            Hp = hp;
            Step = step;
            Attac = attac;
            Damage = damage;
            Name = name;
            IsDamageChange = isChangeDamage;
        }

        
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
        /// <summary>
        /// изменяется ли урон.
        /// </summary>
        public bool IsDamageChange = true;

        public static bool IsDead (Unit selectedUnit)
        {
            if(selectedUnit.Hp == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static int ChangeDamageLevel (Unit attackUnit, Unit targetUnit)
        {
            if (attackUnit.IsDamageChange)
            {
                var dx = Math.Abs(attackUnit.X - targetUnit.X);
                var dy = Math.Abs(attackUnit.Y - targetUnit.Y);

                if ((dx == 0 || dx == 1) && (dy == 0 || dy == 1))
                    return attackUnit.Damage / 2;
                else
                    return attackUnit.Damage;
            }
            else
                return attackUnit.Damage;
        }
    }
}
