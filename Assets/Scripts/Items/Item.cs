using Roguelike.Notifications;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Items
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
    public class Item : SerializedScriptableObject, INotifiable
    {
        [Header("Basic Data")]
        [SerializeField] private new string name = "New Item Name";
        [SerializeField] private string description = "New Item Description";
        [SerializeField] private int price = 1;
        [SerializeField] private bool canDrop = true;
        [SerializeField] private Quality quality = null;
        [SerializeField] private Sprite icon = null;
        [SerializeField] private GameObject model = null;
        [SerializeField] private GameObject passiveLogic = null;

        public string Name => name;
        public string Description => description;
        public int Price => price;
        public bool CanDrop => canDrop;
        public Quality Quality => quality;
        public Sprite Icon => icon;
        public GameObject Model => model;
        public GameObject PassiveLogic => passiveLogic;
    }
}
