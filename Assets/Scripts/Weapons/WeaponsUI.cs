using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Roguelike.Weapons
{
    public class WeaponsUI : MonoBehaviour
    {
        [Required] [SerializeField] private TextMeshProUGUI weaponNameText = null;
        [Required] [SerializeField] private TextMeshProUGUI ammoCountText = null;

        private WeaponInstance displayedWeapon = null;

        public void UpdateDisplayedWeapon(WeaponInstance weaponInstance)
        {
            displayedWeapon = weaponInstance;

            weaponNameText.text = weaponInstance.WeaponData.Name;

            UpdateAmmoCount();
        }

        public void UpdateAmmoCount()
        {
            ammoCountText.text = $"{displayedWeapon.WeaponLogic.CurrentAmmo}/{displayedWeapon.WeaponLogic.MaxAmmo}";
        }
    }
}
