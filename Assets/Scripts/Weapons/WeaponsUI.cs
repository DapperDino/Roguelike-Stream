using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Roguelike.Weapons
{
    public class WeaponsUI : MonoBehaviour
    {
        [Required] [SerializeField] private TextMeshProUGUI weaponNameText = null;
        [Required] [SerializeField] private TextMeshProUGUI ammoCountText = null;

        private WeaponInstance weaponInstance = null;

        public void UpdateDisplayedWeapon(WeaponInstance weaponInstance)
        {
            this.weaponInstance = weaponInstance;

            weaponNameText.text = weaponInstance.weaponData.Name;

            UpdateAmmoCount();
        }

        public void UpdateAmmoCount()
        {
            ammoCountText.text = $"{weaponInstance.weaponLogic.CurrentAmmo}/{weaponInstance.weaponLogic.MaxAmmo}";
        }
    }
}
