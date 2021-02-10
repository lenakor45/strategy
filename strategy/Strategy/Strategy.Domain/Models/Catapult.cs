namespace Strategy.Domain.Models
{
    /// <summary>
    /// Катапульта.
    /// </summary>
    public sealed class Catapult :Unit
    {
        /// <inheritdoc />
        public Catapult(Player player)
        {
            Player = player;
        }


        /// <summary>
        /// Игрок, который управляет юнитом.
        /// </summary>
        public Player Player { get; }
    }
}