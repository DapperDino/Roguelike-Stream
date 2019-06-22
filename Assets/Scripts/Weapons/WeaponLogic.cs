using UnityEngine;

namespace Roguelike.Weapons
{
    public class WeaponLogic : MonoBehaviour
    {
        private int currentAmmo = 0;

        public void Fire() => Debug.Log("Pew");
    }
}
