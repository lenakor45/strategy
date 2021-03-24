using Strategy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Domain
{
    public sealed class Dead : Unit
    {
        public Dead(Player player, int hp = 0, int step = 0, int attac = 0, int damage = 0, string name = "Dead", bool isChangeDamage = false) : base(player, hp, step, attac, damage, name, isChangeDamage)
        {

        }
    }
}
