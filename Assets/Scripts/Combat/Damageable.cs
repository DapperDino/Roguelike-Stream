using UnityEngine;

namespace Roguelike.Combat
{
    public abstract class Damageable : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth = 0;
        [SerializeField] private Transform targetPoint = null;

        public int MaxHealth => maxHealth;
        public int CurrentHealth { get; private set; } = 0;

        public Transform TargetPoint => targetPoint;

        protected virtual void Start() => CurrentHealth = maxHealth;

        public abstract void OnDeath();

        public virtual void DealDamage(int damageAmount)
        {
            if (damageAmount <= 0) { return; }

            CurrentHealth -= damageAmount;

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                OnDeath();
            }
        }

        public virtual void Heal(int healAmount)
        {
            if (healAmount <= 0) { return; }

            CurrentHealth += healAmount;

            if (CurrentHealth > maxHealth)
            {
                CurrentHealth = maxHealth;
            }
        }
    }
}
