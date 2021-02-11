namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс мечника.
    /// </summary>
    public sealed class Swordsman :Unit
    {
        public Swordsman(Player player, int hp = 100):base(player, hp)
        {
            
        }


        
    }
}