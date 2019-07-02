using System;

namespace Roguelike.Combat
{
    public class EnemyDamageable : Damageable
    {
        public event Action<EnemyDamageable> onDeath = delegate { };

        public override void DealDamage(int damageAmount)
        {
            base.DealDamage(damageAmount);
        }

        public override void OnDeath()
        {
            onDeath?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
