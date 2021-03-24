namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс всадника.
    /// </summary>
    public sealed class Horseman :Unit
    {
        /// <inheritdoc />
        public Horseman(Player player, int hp = 200, int step = 10, int attac=1, int damage = 75, string name = "Horseman", bool isChangeDamage = false) :base(player, hp, step, attac, damage, name, isChangeDamage)
            
        {
            
        }

        /// <summary>
        /// Игрок, который управляет юнитом.
        /// </summary>
        
    }
}