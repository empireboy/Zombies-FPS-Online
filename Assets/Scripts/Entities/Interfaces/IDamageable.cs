public interface IDamageable
{
    event DamageEvent OnTakeDamage;

    void TakeDamage(float damage);
}