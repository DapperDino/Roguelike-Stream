using Roguelike.Events.CustomEvents;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Combat
{
    public class EnemyHealthSystem : HealthSystem
    {
        [Required] [SerializeField] private EnemyDamageableEvent onEnemySpawned = null;

        protected override void Start()
        {
            base.Start();

            onEnemySpawned.Raise(this);
        }

        public override void Die()
        {
            base.Die();

            Destroy(gameObject);
        }
    }
}
