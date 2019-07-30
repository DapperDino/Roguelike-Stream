using Roguelike.GameStates;
using Roguelike.Items;
using Roguelike.Rooms;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Interactables
{
    public class ShopItem : Interactable
    {
        [Required] [SerializeField] private Inventory inventory = null;
        [Required] [SerializeField] private ItemDatabase itemDatabase = null;

        private Item item = null;

        private void Start()
        {
            Quality quality = GetComponentInParent<Room>().
                LevelSettings.QualityHandler.
                GetRandomQuality();

            item = itemDatabase.GetItemOfQuality(quality);

            Instantiate(item.Model, transform);
        }

        public override void Interact(GameObject other)
        {
            if (GameState.Money >= item.Price)
            {
                GameState.Money -= item.Price;
                inventory.AddItem(item);
                Destroy(this);
            }
        }
    }
}
