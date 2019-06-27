using Roguelike.Combat;
using UnityEngine;

namespace Roguelike.Actions
{
    public class AreaDamageAction : MonoBehaviour
    {
        [SerializeField] private int damageAmount = 1;
        [SerializeField] private float radius = 1f;
        [SerializeField] private LayerMask layerMask = new LayerMask();

        public void DealDamage()
        {
            Collider[] colliders = Physics.OverlapSphere(
                transform.position,
                radius,
                layerMask);

            foreach (Collider collider in colliders)
            {
                IDamageable damageable = collider.GetComponent<IDamageable>();

                damageable?.DealDamage(damageAmount);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
