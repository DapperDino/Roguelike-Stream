using Roguelike.Events.CustomEvents;
using Roguelike.Weapons;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Items
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Items/Inventory")]
    public class Inventory : ScriptableObject
    {
        [Required] [SerializeField] private ItemEvent onItemAdded = null;
        [Required] [SerializeField] private WeaponDataEvent onWeaponAdded = null;

        public List<WeaponInstance> Weapons { get; } = new List<WeaponInstance>();
        public List<Item> Items { get; } = new List<Item>();

        public bool AddItem(Item item)
        {
            WeaponData weaponData = item as WeaponData;

            if (weaponData != null)
            {
                onWeaponAdded.Raise(weaponData);
            }
            else
            {
                Items.Add(item);
            }

            onItemAdded.Raise(item);

            return true;
        }
    }
}
