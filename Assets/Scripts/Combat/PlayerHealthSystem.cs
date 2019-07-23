using Roguelike.Events.CustomEvents;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Combat
{
    public class PlayerHealthSystem : HealthSystem
    {
        [Required] [SerializeField] private DamageableEvent onPlayerSpawn = null;

        protected override void Start()
        {
            base.Start();

            onPlayerSpawn.Raise(this);
        }

        public override void DealDamage(int damageAmount)
        {
            base.DealDamage(1);      
        }
    }
}
