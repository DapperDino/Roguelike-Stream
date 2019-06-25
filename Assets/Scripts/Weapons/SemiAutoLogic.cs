using UnityEngine;

namespace Roguelike.Weapons
{
    public class SemiAutoLogic : WeaponLogic
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }
    }
}
