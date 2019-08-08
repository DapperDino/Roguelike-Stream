using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Roguelike.Items
{
    [CreateAssetMenu(fileName = "New Item Database", menuName = "Items/Item Database")]
    public class ItemDatabase : ScriptableObject
    {
        [SerializeField] private Item[] items = new Item[0];

        private List<Item> spawnedItems = new List<Item>();

        private IEnumerable<Item> AvailableItems => items.Except(spawnedItems);

        [Button]
        public void GetAndSortItems()
        {
            items = Resources.LoadAll<Item>("Items");
            items = items.OrderBy(item => item.Name).ToArray();
        }

        public Item GetItemOfQuality(Quality quality)
        {
            Item[] itemsOfQuality = AvailableItems.Where((item) => item.Quality == quality).ToArray();

            if (itemsOfQuality.Length == 0)
            {
                itemsOfQuality = items.Where((item) => item.Quality == quality).ToArray();
            }

            Item itemOfQuality = itemsOfQuality[Random.Range(0, itemsOfQuality.Length)];

            spawnedItems.Add(itemOfQuality);

            return itemOfQuality;
        }

        public Item GetItemByName(string itemName)
        {
            itemName = itemName.ToLower();

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Name.ToLower() == itemName)
                {
                    return items[i];
                }
            }

            return null;
        }
    }
}
