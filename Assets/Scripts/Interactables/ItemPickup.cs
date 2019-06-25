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

        protected override void Enter()
        {
            //Enable outline.
        }

        protected override void Interact()
        {
            if (inventory.AddItem(item))
            {
                Destroy(gameObject);              
            }
        }

        protected override void Exit()
        {
            //Disable outline.
        }
    }
}