using System;
using UnityEngine;

namespace Roguelike.Weapons
{
    [Serializable]
    public class WeaponInstance
    {
        [SerializeField] private WeaponData weaponData = null;
        [SerializeField] private WeaponLogic weaponLogic = null;

        public WeaponInstance(WeaponData weaponData, WeaponLogic weaponLogic)
        {
            this.weaponData = weaponData;
            this.weaponLogic = weaponLogic;
        }

        public WeaponData WeaponData => weaponData;
        public WeaponLogic WeaponLogic => weaponLogic;
    }
}

