using UnityEngine;

namespace Roguelike.Items
{
    public abstract class Item : ScriptableObject
    {
        [Header("Basic Data")]
        [SerializeField] private new string name = "New Item Name";
        [SerializeField] private string description = "New Item Description";
        [SerializeField] private Quality quality = null;
        [SerializeField] private Sprite icon = null;
        [SerializeField] private GameObject model = null;

        public string Name => name;
        public string Description => description;
        public Quality Quality => quality;
        public Sprite Icon => icon;
        public GameObject Model => model;
    }
}
