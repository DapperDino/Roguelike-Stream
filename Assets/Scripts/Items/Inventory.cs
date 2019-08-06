using Roguelike.Events.UnityEvents;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Items
{
    public class Inventory : MonoBehaviour
    {
        [Required] [SerializeField] private UnityItemEvent onItemAdded = null;

        public void AddItem(Item item) => onItemAdded.Invoke(item);
    }
}
