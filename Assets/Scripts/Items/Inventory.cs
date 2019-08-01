using Roguelike.Events.UnityEvents;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Items
{
    public class Inventory : MonoBehaviour
    {
        [Required] [SerializeField] private UnityItemEvent onItemAdded = null;
        [Required] [SerializeField] private UnityItemEvent onItemRemoved = null;

        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);

            onItemAdded.Invoke(item);
        }

        public void RemoveItem(Item item)
        {
            if (!item.CanDrop) { return; }

            if (!items.Contains(item)) { return; }

            items.Remove(item);

            onItemRemoved.Invoke(item);
        }
    }
}
