namespace Strategy.Domain.Models
{
    /// <summary>
    /// Лучник.
    /// </summary>
    public sealed class Archer :Unit
    {
        /// <inheritdoc />
        public Archer(Player player, int hp = 50, int step = 3, int attac= 5, int damage = 50, string name = "Archer", bool isChangeDamage = true) : base(player, hp, step, attac, damage, name, isChangeDamage)
        {
          
        }

    }
}