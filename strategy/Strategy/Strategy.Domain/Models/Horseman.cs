namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс всадника.
    /// </summary>
    public sealed class Horseman :Unit
    {
        /// <inheritdoc />
        public Horseman(Player player, int hp = 200) :base(player, hp)
            
        {
            
        }

        /// <summary>
        /// Игрок, который управляет юнитом.
        /// </summary>
        
    }
}