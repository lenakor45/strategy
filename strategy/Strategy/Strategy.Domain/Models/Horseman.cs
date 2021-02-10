namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс всадника.
    /// </summary>
    public sealed class Horseman :Unit
    {
        /// <inheritdoc />
        public Horseman(Player player)
        {
            Player = player;
        }

        /// <summary>
        /// Игрок, который управляет юнитом.
        /// </summary>
        public Player Player { get; }
    }
}