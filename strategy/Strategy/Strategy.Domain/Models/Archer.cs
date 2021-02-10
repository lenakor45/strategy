namespace Strategy.Domain.Models
{
    /// <summary>
    /// Лучник.
    /// </summary>
    public sealed class Archer :Unit
    {
        /// <inheritdoc />
        public Archer(Player player)
        {
            Player = player;
        }



        /// <summary>
        /// Игрок, который управляет юнитом.
        /// </summary>
        public Player Player { get; }
    }
}