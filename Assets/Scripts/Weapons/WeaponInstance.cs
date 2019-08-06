using System;

namespace Roguelike.Weapons
{
    [Serializable]
    public class WeaponInstance
    {
        public WeaponData weaponData = null;
        public PlayerWeaponLogic weaponLogic = null;
    }
}

