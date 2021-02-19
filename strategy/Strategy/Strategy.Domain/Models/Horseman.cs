namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс всадника.
    /// </summary>
    public sealed class Horseman :Unit
    {
        /// <inheritdoc />
        public Horseman(Player player, int hp = 200, int step = 10, int attac=1, int damage = 75) :base(player, hp, step, attac, damage)
            
        {
            
        }

        /// <summary>
        /// Игрок, который управляет юнитом.
        /// </summary>
        
    }
}