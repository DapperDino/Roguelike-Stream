using System;

namespace Roguelike.Combat
{
    public class EnemyDamageable : Damageable
    {
        public event Action onDeath = delegate { };

        public override void DealDamage(int damageAmount)
        {
            base.DealDamage(damageAmount);
        }

        public override void OnDeath()
        {
            onDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
