using Roguelike.Combat;
using UnityEngine;

namespace Roguelike.OnContact
{
    public class DealDamageOnContact : MonoBehaviour
    {
        [SerializeField] private int damageAmount = 1;

        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();

            damageable?.DealDamage(damageAmount);
        }
    }
}
