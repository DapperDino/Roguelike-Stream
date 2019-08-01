using Roguelike.Items;
using UnityEngine;

namespace Roguelike.Interactables
{
    public class ItemPickup : Interactable
    {
        private Item item = null;

        public void Initialise(Item item)
        {
            Instantiate(item.Model, transform);
            this.item = item;
        }

        public override void Interact(GameObject other)
        {
            var inventory = other.GetComponent<Inventory>();

            if (inventory == null) { return; }

            inventory.AddItem(item);

            Destroy(gameObject);
        }
    }
}