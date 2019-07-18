using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Items
{
    public class PassiveItemHandler : MonoBehaviour
    {
        private List<PassiveItemInstance> aquiredItems = new List<PassiveItemInstance>();
        private List<PassiveItemInstance> currentItems = new List<PassiveItemInstance>();

        public void CheckForPassiveItemAdd(Item item)
        {
            if (item.PassiveLogic == null) { return; }

            AddNewPassiveItem(item);
        }

        private void AddNewPassiveItem(Item item)
        {
            PassiveItemInstance itemInstance = null;

            for (int i = 0; i < aquiredItems.Count; i++)
            {
                if (aquiredItems[i].item == item)
                {
                    itemInstance = aquiredItems[i];
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

                aquiredItems.Add(itemInstance);
            }

            currentItems.Add(itemInstance);
        }
    }
}

