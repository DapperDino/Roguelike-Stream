using Roguelike.Items;
using Roguelike.Rooms;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Interactables
{
    public class Chest : Interactable
    {
        [Required] [SerializeField] private ItemDatabase itemDatabase = null;
        [Required] [SerializeField] private GameObject itemPickup = null;
        [SerializeField] private Vector3 itemSpawnOffset = new Vector3(0f, 1f, 1f);

        private Item item = null;

        private void Start()
        {
            Quality quality = GetComponentInParent<Room>().
                LevelSettings.QualityHandler.
                GetRandomQuality();

            GetComponentInChildren<Renderer>().material.color = quality.Colour;

            item = itemDatabase.GetItemOfQuality(quality);
        }

        protected override void Enter()
        {
            //Enable outline.
        }

        protected override void Interact()
        {
            GameObject itemPickupInstance = Instantiate(
                itemPickup,
                transform.position + transform.TransformDirection(itemSpawnOffset),
                transform.rotation);

            itemPickupInstance.GetComponent<ItemPickup>().Initialise(item);

            Destroy(this);
        }

        protected override void Exit()
        {
            //Disable outline.
        }
    }
}
