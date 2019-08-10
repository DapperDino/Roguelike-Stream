using Roguelike.Events.CustomEvents;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Combat
{
    public class PlayerHealthSystem : HealthSystem
    {
        [Required] [SerializeField] private DamageableEvent onPlayerSpawn = null;
        [SerializeField] private float invunerabilityDuration = 0.5f;
        
        private float lastInvunerabilityTime = Mathf.NegativeInfinity;

        protected override void Start()
        {
            base.Start();

            onPlayerSpawn.Raise(this);
        }

        public override void DealDamage(int damageAmount)
        {
            if (lastInvunerabilityTime + invunerabilityDuration > Time.time) { return; }

            base.DealDamage(1);

            lastInvunerabilityTime = Time.time;
        }
    }
}
