using Roguelike.Items;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Interactables
{
    public class ItemPickup : Interactable
    {
        [Required] [SerializeField] private Inventory inventory = null;

        private Item item = null;

        public void Initialise(Item item)
        {
            Instantiate(item.Model, transform);
            this.item = item;
        }

        public override void Interact(GameObject other)
        {
            if (inventory.AddItem(item))
            {
                Destroy(gameObject);              
            }
        }
    }
}