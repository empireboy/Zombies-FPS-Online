using CM.Events;

public interface IHealth : IActivatable
{
    event DamageEvent OnTakeDamage;
    event SimpleEvent OnKill;

    void TakeDamage(float damage);
    void Kill();
}