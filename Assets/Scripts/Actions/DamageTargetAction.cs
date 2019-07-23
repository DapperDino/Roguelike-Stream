using Roguelike.Combat;
using Roguelike.Combat.Stats;
using UnityEngine;

namespace Roguelike.Actions
{
    public class DamageTargetAction : MonoBehaviour
    {
        [SerializeField] private int damageAmount = 1;

        private StatsContainer statsContainer = null;

        private void Start()
        {
            statsContainer = GetComponentInParent<StatsContainer>();
        }

        public void DealDamage(Transform other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();

            float multiplier = 1f;

            if (statsContainer != null)
            {
                multiplier += statsContainer.GetStatValue(StatTypes.DamageMultiplier);
            }

            damageable?.DealDamage((int)(damageAmount * multiplier));
        }
    }
}
