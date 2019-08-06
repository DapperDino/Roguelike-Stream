using System.Collections.Generic;
using System.Linq;
using Roguelike.Inputs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Items
{
    public class ActiveItemHandler : MonoBehaviour
    {
        [Required] [SerializeField] private InputContainer inputContainer = null;

        [SerializeField] private Dictionary<ActiveItem, float> items = new Dictionary<ActiveItem, float>();
        private int currentIndex = 0;

        private ActiveItem CurrentItem
        {
            get
            {
                if (currentIndex >= items.Count) { return null; }
                return items.ElementAt(currentIndex).Key;
            }
        }

        public void CheckForActiveItemAdd(Item item)
        {
            if (item is ActiveItem activeItem)
            {
                AddNewActiveItem(activeItem);
            }
        }

        private void AddNewActiveItem(ActiveItem item)
        {
            items.Add(item, Mathf.NegativeInfinity);
        }

        private void Update()
        {
            HandleItemSwitching();

            CheckToUseItem();
        }

        private void CheckToUseItem()
        {
            if (inputContainer.ActiveItemUse)
            {
                ActiveItem item = CurrentItem;

                if (item == null) { return; }

                if (Time.time - items[item] < item.Cooldown) { return; }

                Instantiate(item.ActiveLogic, transform);

                items[item] = Time.time;
            }
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

