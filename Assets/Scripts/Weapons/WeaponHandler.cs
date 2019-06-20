using UnityEngine;

namespace Roguelike.Weapons
{
    public class WeaponHandler : MonoBehaviour
    {
        private Weapon currentWeapon = null;

        public void SetWeapon(Weapon weapon)
        {
            if (currentWeapon != null)
            {
                Destroy(currentWeapon);
            }
            currentWeapon = Instantiate(weapon, transform);
        }

        private void Update() => HandleFiring();

        private void HandleFiring()
        {
            if (currentWeapon == null) { return; }

            if (Input.GetMouseButtonDown(0))
            {
                currentWeapon.Fire();
            }
        }
    }
}
