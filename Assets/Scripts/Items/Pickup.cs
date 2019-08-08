using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Items
{
    [CreateAssetMenu(fileName = "New Pickup", menuName = "Items/Pickup")]
    public class Pickup : Item
    {
        [Required] [SerializeField] private GameObject pickupLogic = null;

        public GameObject PickupLogic => pickupLogic;
    }
}