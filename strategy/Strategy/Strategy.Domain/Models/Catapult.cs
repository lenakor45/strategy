namespace Strategy.Domain.Models
{
    /// <summary>
    /// Катапульта.
    /// </summary>
    public sealed class Catapult :Unit
    {
        /// <inheritdoc />
        public Catapult(Player player, int hp = 75, int step = 1, int attac = 10, int damage = 100):base(player, hp, step, attac, damage)
        {
           
        }

    }
}