using Roguelike.Combat;
using UnityEngine;

namespace Roguelike.Actions
{
    public class DamageTargetAction : MonoBehaviour
    {
        [SerializeField] private int damageAmount = 1;

        public void DealDamage(Transform other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();

            damageable?.DealDamage(damageAmount);
        }
    }
}
