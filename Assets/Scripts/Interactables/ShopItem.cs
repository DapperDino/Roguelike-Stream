using Roguelike.GameStates;
using Roguelike.Items;
using Roguelike.Rooms;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Interactables
{
    public class ShopItem : Interactable
    {
        [Required] [SerializeField] private ItemDatabase itemDatabase = null;

        private Item item = null;

        private void Start()
        {
            Quality quality = GetComponentInParent<Room>().
                LevelSettings.QualityHandler.
                GetRandom();

            item = itemDatabase.GetItemOfQuality(quality);

            Instantiate(item.Model, transform);
        }

        public override void Interact(GameObject other)
        {
            var inventory = other.GetComponent<Inventory>();

            if (inventory == null) { return; }

            var currency = other.GetComponent<Currency>();

            if (currency == null) { return; }

            if (currency.Money >= item.Price)
            {
                currency.Money -= item.Price;
                inventory.AddItem(item);
                Destroy(this);
            }
        }
    }
}
