using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Items
{
    public class PassiveItemHandler : MonoBehaviour
    {
        [SerializeField] private List<PassiveItemInstance> acquiredItems = new List<PassiveItemInstance>();
        
        private List<PassiveItemInstance> currentItems = new List<PassiveItemInstance>();

        private void Start()
        {
            for (int i = 0; i < acquiredItems.Count; i++)
            {
                AddNewPassiveItem(acquiredItems[i].item);
            }
        }

        public void CheckForPassiveItemAdd(Item item)
        {
            if (item.PassiveLogic == null) { return; }

            AddNewPassiveItem(item);
        }

        private void AddNewPassiveItem(Item item)
        {
            PassiveItemInstance itemInstance = null;

            for (int i = 0; i < acquiredItems.Count; i++)
            {
                if (acquiredItems[i].item == item)
                {
                    itemInstance = acquiredItems[i];
                    break;
                }
            }

            if (itemInstance == null)
            {
                itemInstance = new PassiveItemInstance
                {
                    item = item,
                    passiveLogic = Instantiate(item.PassiveLogic, transform).GetComponent<PassiveItemLogic>()
                };

                acquiredItems.Add(itemInstance);
            }

            currentItems.Add(itemInstance);
        }
    }
}

