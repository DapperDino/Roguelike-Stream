using Roguelike.Items;
using UnityEngine;

namespace Roguelike.Weapons
{
    [CreateAssetMenu(fileName = "New Weapon Data", menuName = "Weapons/Weapon Data")]
    public class WeaponData : Item
    {
        [Header("Weapon Data")]
        [SerializeField] private GameObject weaponLogic = null;

        public GameObject WeaponLogic => weaponLogic;
    }
}
