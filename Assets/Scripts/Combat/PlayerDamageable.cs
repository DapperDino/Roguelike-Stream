using Roguelike.Events.CustomEvents;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Combat
{
    public class PlayerDamageable : Damageable
    {
        [Required] [SerializeField] private DamageableEvent onPlayerSpawn = null;
        [Required] [SerializeField] private VoidEvent onPlayerDeath = null;
        [Required] [SerializeField] private VoidEvent onPlayerTakeDamage = null;

        protected override void Start()
        {
            base.Start();

            onPlayerSpawn.Raise(this);
        }

        public override void DealDamage(int damageAmount)
        {
            base.DealDamage(1);
            onPlayerTakeDamage.Raise();
        }

        public override void OnDeath() => onPlayerDeath.Raise();
    }
}
