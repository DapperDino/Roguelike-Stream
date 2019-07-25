using Roguelike.Items;
using UnityEngine;

namespace Roguelike.Characters
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Characters/Character")]
    public class Character : ScriptableObject
    {
        [SerializeField] private new string name = "New Character Name";
        [SerializeField] private GameObject prefab = null;
        [SerializeField] private GameObject visuals = null;
        [SerializeField] private Item[] startingItems = new Item[0];

        public string Name => name;
        public GameObject Prefab => prefab;
        public GameObject Visuals => visuals;
        public Item[] StartingItems => startingItems;
    }
}
