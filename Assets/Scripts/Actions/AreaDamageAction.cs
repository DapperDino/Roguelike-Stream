using Roguelike.Combat;
using Roguelike.Combat.Stats;
using UnityEngine;

namespace Roguelike.Actions
{
    public class AreaDamageAction : MonoBehaviour
    {
        [SerializeField] private int damageAmount = 1;
        [SerializeField] private float radius = 1f;
        [SerializeField] private LayerMask layerMask = new LayerMask();

        private StatsContainer statsContainer = null;

        private void Start()
        {
            statsContainer = GetComponentInParent<StatsContainer>();
        }

        public void DealDamage()
        {
            Collider[] colliders = Physics.OverlapSphere(
                transform.position,
                radius,
                layerMask);

            foreach (Collider collider in colliders)
            {
                var damageable = collider.GetComponent<IDamageable>();

                float multiplier = 1f;

                if (statsContainer != null)
                {
                    multiplier += statsContainer.GetStatValue(StatTypes.DamageMultiplier);
                }

                damageable?.DealDamage((int)(damageAmount * multiplier));
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
