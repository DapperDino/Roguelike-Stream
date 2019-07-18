using Roguelike.Events.CustomEvents;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Items
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Items/Inventory")]
    public class Inventory : ScriptableObject
    {
        [Required] [SerializeField] private ItemEvent onItemAdded = null;
        [Required] [SerializeField] private ItemEvent onItemRemoved = null;

        private List<Item> items = new List<Item>();

        public bool AddItem(Item item)
        {
            items.Add(item);

            onItemAdded.Raise(item);

            return true;
        }

        [Button]
        public void RemoveItem(Item item)
        {
            if (!item.CanDrop) { return; }

            if (!items.Contains(item)) { return; }

            items.Remove(item);

            onItemRemoved.Raise(item);
        }
    }
}
