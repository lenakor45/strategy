namespace Strategy.Domain.Models
{
    /// <summary>
    /// Проходимая поверхность на земле.
    /// </summary>
    public sealed class Grass :Ground
    {
        /// <inheritdoc />
        public Grass(string name = "Grass") :base( name)
        {
        }

       
    }
}