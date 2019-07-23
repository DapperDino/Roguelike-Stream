using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Combat
{
    public class HealthStatsUI : MonoBehaviour
    {
        [Required] [SerializeField] private GameObject healthIconPrefab = null;
        [Required] [SerializeField] private Transform healthIconsHolderTransform = null;

        private List<GameObject> healthIcons = new List<GameObject>();

        public void UpdateHealth(int health)
        {
            for (int i = 0; i < healthIcons.Count; i++)
            {
                healthIcons[i].SetActive(health >= i + 1);
            }
        }

        public void UpdateMaxHealth(int maxHealth)
        {
            for (int i = 0; i < maxHealth; i++)
            {
                if (healthIcons.Count <= i)
                {
                    healthIcons.Add(Instantiate(healthIconPrefab, healthIconsHolderTransform));
                }
            }

            for (int i = healthIcons.Count - 1; i >= 0; i--)
            {
                if (maxHealth <= i)
                {
                    Destroy(healthIcons[i].gameObject);
                    healthIcons.RemoveAt(i);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
