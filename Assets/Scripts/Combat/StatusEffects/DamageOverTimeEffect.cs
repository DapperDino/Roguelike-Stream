using UnityEngine;

namespace Roguelike.Combat.StatusEffects
{
    public class DamageOverTimeEffect : StatusEffect
    {
        [SerializeField] private int damagePerTick = 1;

        private HealthSystem damageable = null;

        public override void Initialise(Transform entity)
        {
            base.Initialise(entity);

            damageable = entity.GetComponent<HealthSystem>();
        }

        public override void Tick()
        {
            base.Tick();

            damageable?.DealDamage(damagePerTick);
        }
    }
}
