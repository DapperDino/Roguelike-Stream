using Roguelike.Combat;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Player
{
    public class PlayerStatsUI : MonoBehaviour
    {
        [Required] [SerializeField] private GameObject healthIconPrefab = null;
        [Required] [SerializeField] private Transform healthIconHolderTransform = null;

        private List<GameObject> healthIcons = new List<GameObject>();
        private Damageable damageable = null;

        public void SetDamageable(Damageable damageable)
        {
            this.damageable = damageable;
            UpdateHealthUI();
        }

        public void UpdateHealthUI()
        {
            for (int i = 0; i < damageable.MaxHealth; i++)
            {
                if (healthIcons.Count <= i)
                {
                    healthIcons.Add(Instantiate(healthIconPrefab, healthIconHolderTransform));
                }

                healthIcons[i].SetActive(damageable.CurrentHealth >= i + 1);
            }
        }
    }
}
