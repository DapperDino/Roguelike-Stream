using Roguelike.Combat;
using UnityEngine;

namespace Roguelike.Weapons
{
    public class HitscanDamage : MonoBehaviour
    {
        [SerializeField] private int damageAmount;
        [SerializeField] private float range = 10;

        private bool isBeaming = false;

        public void Fire()
        {
            Debug.DrawRay(transform.position, transform.forward * range, Color.magenta, 0.25f);

            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range))
            {
                IDamageable damageable = hit.transform.GetComponent<IDamageable>();

                damageable?.DealDamage(damageAmount);
            }
        }
    }
}
