using UnityEngine;

namespace Roguelike.Combat
{
    public class Fragile : MonoBehaviour, IDamageable
    {
        public void DealDamage(int damageAmount) => Destroy(gameObject);
    }
}
