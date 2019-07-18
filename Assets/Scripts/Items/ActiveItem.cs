using UnityEngine;

namespace Roguelike.Items
{
    public class ActiveItem : Item
    {
        [SerializeField] private GameObject activeLogic = null;

        public GameObject ActiveLogic => activeLogic;
    }
}