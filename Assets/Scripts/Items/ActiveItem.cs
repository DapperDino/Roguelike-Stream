using UnityEngine;

namespace Roguelike.Items
{
    [CreateAssetMenu(fileName = "New Active Item", menuName = "Items/Active Item")]
    public class ActiveItem : Item
    {
        [SerializeField] private float cooldown = 10f;
        [SerializeField] private GameObject activeLogic = null;

        public float Cooldown => cooldown;
        public GameObject ActiveLogic => activeLogic;
    }
}