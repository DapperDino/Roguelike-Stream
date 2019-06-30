using Roguelike.Events.CustomEvents;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Combat
{
    public class PlayerDamageable : Damageable
    {
        [Required] [SerializeField] VoidEvent onPlayerDeath = null;

        public override void DealDamage(int damageAmount) => base.DealDamage(1);

        public override void OnDeath() => onPlayerDeath.Raise();
    }
}
