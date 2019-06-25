using UnityEngine;

namespace Roguelike.Combat
{
    public abstract class Damageable : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth = 0;

        private int currentHealth = 0;

        private void Start() => currentHealth = maxHealth;

        public abstract void OnDeath();

        public virtual void DealDamage(int damageAmount)
        {
            if (damageAmount <= 0) { return; }

            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                OnDeath();
            }
        }

        public virtual void Heal(int healAmount)
        {
            if (healAmount <= 0) { return; }

            currentHealth += healAmount;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
}
