using System.Collections.Generic;
using Roguelike.Inputs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Items
{
    public class ActiveItemHandler : MonoBehaviour
    {
        [Required] [SerializeField] private InputContainer inputContainer = null;

        private List<ActiveItem> items = new List<ActiveItem>();
        private int currentIndex = 0;

        private ActiveItem CurrentItem => items[currentIndex];

        public void CheckForActiveItemAdd(Item item)
        {
            if (item is ActiveItem activeItem)
            {
                AddNewActiveItem(activeItem);
            }
        }

        private void AddNewActiveItem(ActiveItem item)
        {
            items.Add(item);
        }

        private void Update()
        {
            HandleItemSwitching();
        }

        private void HandleItemSwitching()
        {
            if (items.Count < 2) { return; }

            if (!inputContainer.ActiveItemSwitch) { return; }

            if (items.Count - 1 == currentIndex)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex += 1;
            }
        }
    }
}

