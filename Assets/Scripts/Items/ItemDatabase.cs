using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;

namespace Roguelike.Items
{
    [CreateAssetMenu(fileName = "New Item Database", menuName = "Items/Item Database")]
    public class ItemDatabase : ScriptableObject
    {
        [SerializeField] private Item[] items = new Item[0];

        [Button]
        public void GetAndSortItems()
        {
            items = Resources.LoadAll<Item>("Items");
            items = items.OrderBy(item => item.Name).ToArray();
        }

        public Item GetItemOfQuality(Quality quality)
        {
            Item[] itemsOfQuality = items.Where((item) => item.Quality == quality).ToArray();

            return itemsOfQuality[Random.Range(0, itemsOfQuality.Length)];
        }

        public Item GetItemByName(string itemName)
        {
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
