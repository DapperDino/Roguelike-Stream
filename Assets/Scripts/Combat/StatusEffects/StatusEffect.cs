using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Combat.StatusEffects
{
    public abstract class StatusEffect
    {
        [Required] [SerializeField] private StatusEffectType statusEffectType = null;
        [SerializeField] private int ticks = 1;
        [SerializeField] private float tickRate = 1f;

        private int remainingTicks = 0;
        private float lastTickTime = 0f;

        public bool ShouldRemove => remainingTicks == 0;
        public StatusEffectType StatusEffectType => statusEffectType;

        public bool ShouldTick(float currentTime) => (1 / tickRate) <= (currentTime - lastTickTime);

        public virtual void Initialise(Transform entity)
        {
            remainingTicks = ticks;
        }

        public virtual void Tick()
        {
            remainingTicks--;

            lastTickTime = Time.time;
        }

        public virtual void Finish() { }
    }
}
