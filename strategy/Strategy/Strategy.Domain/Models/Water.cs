namespace Strategy.Domain.Models
{
    /// <summary>
    /// Непроходимая наземная поверхность.
    /// </summary>
    public sealed class Water :Ground
    {
        /// <inheritdoc />
        public Water(string name = "Water") : base(name)
        {
        }

        
    }
}