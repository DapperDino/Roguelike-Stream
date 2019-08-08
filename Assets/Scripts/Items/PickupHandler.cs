using UnityEngine;

namespace Roguelike.Items
{
    public class PickupHandler : MonoBehaviour
    {
        public void CheckForPassiveItemAdd(Item item)
        {
            if (item is Pickup pickup)
            {
                Instantiate(pickup.PickupLogic, transform);
            }
        }
    }
}

