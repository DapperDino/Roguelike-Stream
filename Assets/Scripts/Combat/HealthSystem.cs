using Roguelike.Combat.Stats;
using Roguelike.Events.UnityEvents;
using UnityEngine;
using UnityEngine.Events;

namespace Roguelike.Combat
{
    public abstract class HealthSystem : MonoBehaviour, IDamageable, IHealable
    {
        [SerializeField] private UnityHealthSystemEvent onSpawn = null;
        [SerializeField] private UnityHealthSystemEvent onDeath = null;
        [SerializeField] private UnityEvent onTakeDamage = null;
        [SerializeField] private UnityIntEvent onHealthChange = null;
        [SerializeField] private UnityIntEvent onMaxHealthChange = null;
        [SerializeField] private int maxHealth = 0;
        [SerializeField] private Transform targetPoint = null;

        private int currentHealth = 0;
        private StatsContainer statsContainer = null;

        public Transform TargetPoint => targetPoint;
        public UnityHealthSystemEvent OnDeath => onDeath;

        private int MaxHealth
        {
            get
            {
                int bonusHealth = statsContainer == null ? 0 : (int)statsContainer.GetStatValue(StatTypes.BonusMaxHp);
                return maxHealth + bonusHealth;
            }
        }

        protected virtual void Start()
        {
            statsContainer = GetComponent<StatsContainer>();

            currentHealth = MaxHealth;

            onHealthChange?.Invoke(currentHealth);

            onMaxHealthChange?.Invoke(MaxHealth);

            onSpawn?.Invoke(this);
        }

        public virtual void DealDamage(int damageAmount)
        {
            if (damageAmount <= 0) { return; }

            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }

            onHealthChange?.Invoke(currentHealth);
        }

        public virtual void Heal(int healAmount)
        {
            if (healAmount <= 0) { return; }

            currentHealth += healAmount;

            if (currentHealth > MaxHealth)
            {
                currentHealth = MaxHealth;
            }

            onHealthChange?.Invoke(currentHealth);
        }

        public void UpdateMaxHealth()
        {
            onMaxHealthChange?.Invoke(MaxHealth);
        }

        public virtual void Die()
        {
            onDeath?.Invoke(this);
        }
    }
}
