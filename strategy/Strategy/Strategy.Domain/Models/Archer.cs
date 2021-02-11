namespace Strategy.Domain.Models
{
    /// <summary>
    /// Лучник.
    /// </summary>
    public sealed class Archer :Unit
    {
        /// <inheritdoc />
        public Archer(Player player) : base(player)
        {
           
        }

    }
}