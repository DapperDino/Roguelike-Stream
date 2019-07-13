using Roguelike.Events.CustomEvents;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace Roguelike.Combat
{
    public class EnemyDamageable : Damageable
    {
        [Required] [SerializeField] private EnemyDamageableEvent onEnemySpawned = null;

        public event Action<EnemyDamageable> onDeath = delegate { };

        protected override void Start()
        {
            base.Start();

            onEnemySpawned.Raise(this);
        }

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
