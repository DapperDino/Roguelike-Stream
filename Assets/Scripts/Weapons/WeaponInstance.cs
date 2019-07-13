using System;
using UnityEngine;

namespace Roguelike.Weapons
{
    [Serializable]
    public class WeaponInstance
    {
        [SerializeField] private WeaponData weaponData = null;
        [SerializeField] private PlayerWeaponLogic playerWeaponLogic = null;

        public WeaponInstance(WeaponData weaponData, PlayerWeaponLogic playerWeaponLogic)
        {
            this.weaponData = weaponData;
            this.playerWeaponLogic = playerWeaponLogic;
        }

        public WeaponData WeaponData => weaponData;
        public PlayerWeaponLogic PlayerWeaponLogic => playerWeaponLogic;
    }
}

