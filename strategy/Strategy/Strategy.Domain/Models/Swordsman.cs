namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс мечника.
    /// </summary>
    public sealed class Swordsman :Unit
    {
        public Swordsman(Player player, int hp = 100, int step = 5, int attac = 1, int damage = 50):base(player, hp, step, attac, damage)
        {
            
        }


        
    }
}