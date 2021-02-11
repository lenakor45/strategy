namespace Strategy.Domain.Models
{
    /// <summary>
    /// Катапульта.
    /// </summary>
    public sealed class Catapult :Unit
    {
        /// <inheritdoc />
        public Catapult(Player player, int hp = 75):base(player, hp)
        {
           
        }

    }
}