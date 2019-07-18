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
        [Required] [SerializeField] private IntEvent onPlayerHealthChange = null;
        [Required] [SerializeField] private IntEvent onPlayerMaxHealthChange = null;

        protected override void Start()
        {
            base.Start();

            onPlayerSpawn.Raise(this);

            onPlayerMaxHealthChange.Raise(MaxHealth);
        }

        public override void DealDamage(int damageAmount)
        {
            base.DealDamage(1);
            
            onPlayerTakeDamage.Raise();

            onPlayerHealthChange.Raise(CurrentHealth);
        }

        public override void OnDeath() => onPlayerDeath.Raise();
    }
}
