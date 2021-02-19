namespace Strategy.Domain.Models
{
    /// <summary>
    /// Лучник.
    /// </summary>
    public sealed class Archer :Unit
    {
        /// <inheritdoc />
        public Archer(Player player, int hp = 50) : base(player, hp)
        {
          
        }

    }
}