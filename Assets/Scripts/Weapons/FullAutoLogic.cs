using UnityEngine;

namespace Roguelike.Weapons
{
    public class FullAutoLogic : WeaponLogic
    {
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Fire();
            }
        }
    }
}
