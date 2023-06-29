namespace Mechanics.Healths
{
    public interface IHealth
    {
        float MaxHealth { get; set; }
        void Die();
    }
}
