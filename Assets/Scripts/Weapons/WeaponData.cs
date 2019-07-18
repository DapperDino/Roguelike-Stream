using Roguelike.Items;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Weapons
{
    [CreateAssetMenu(fileName = "New Weapon Data", menuName = "Weapons/Weapon Data")]
    public class WeaponData : Item
    {
        [Header("Weapon Data")]
        [Required] [SerializeField] private GameObject weaponLogic = null;

        public GameObject WeaponLogic => weaponLogic;
    }
}
