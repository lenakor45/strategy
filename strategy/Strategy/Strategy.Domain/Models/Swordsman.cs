namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс мечника.
    /// </summary>
    public sealed class Swordsman :Unit
    {
        public Swordsman(Player player)
        {
            Player = player;
        }


        /// <summary>
        /// Игрок, который управляет юнитом.
        /// </summary>
        public Player Player { get; }
    }
}