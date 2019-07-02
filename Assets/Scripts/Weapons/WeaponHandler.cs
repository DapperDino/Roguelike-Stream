using Roguelike.Inputs;
using Roguelike.Items;
using Roguelike.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Weapons
{
    public class WeaponHandler : MonoBehaviour
    {
        [Required] [SerializeField] private InputContainer inputContainer = null;
        [Required] [SerializeField] private Inventory inventory = null;

        private int currentIndex = 0;

        private WeaponInstance CurrentWeapon
        {
            get
            {
                return inventory.Weapons.Count < currentIndex + 1 ? null : inventory.Weapons[currentIndex];
            }
        }

        public void AddNewWeapon(WeaponData weaponData)
        {
            WeaponLogic weaponLogic = Instantiate(
                weaponData.WeaponLogic,
                transform).
                GetComponent<WeaponLogic>();

            weaponLogic.Initialise(inputContainer);

            inventory.Weapons.Add(new WeaponInstance(weaponData, weaponLogic));

            weaponLogic.gameObject.SetActive(weaponLogic == CurrentWeapon.WeaponLogic);
        }

        private void Update()
        {
            HandleWeaponSwitching();
        }

        private void HandleWeaponSwitching()
        {
            if (inventory.Weapons.Count < 2) { return; }

            for (int i = 0; i < ExtensionMethods.NumKeys.Length; i++)
            {
                if (Input.GetKeyDown(ExtensionMethods.NumKeys[i]))
                {
                    if (inventory.Weapons.Count < i + 1) { return; }

                    ChangeWeapon(i);
                }
            }

            float scrollDelta = inputContainer.ScrollInput;

            if (scrollDelta > 0)
            {
                if (inventory.Weapons.Count - 1 == currentIndex)
                {
                    ChangeWeapon(0);
                }
                else
                {
                    ChangeWeapon(currentIndex + 1);
                }
            }
            else if (scrollDelta < 0)
            {
                if (currentIndex == 0)
                {
                    ChangeWeapon(inventory.Weapons.Count - 1);
                }
                else
                {
                    ChangeWeapon(currentIndex - 1);
                }
            }
        }

        private void ChangeWeapon(int index)
        {
            CurrentWeapon.WeaponLogic.gameObject.SetActive(false);

            currentIndex = index;

            CurrentWeapon.WeaponLogic.gameObject.SetActive(true);
        }
    }
}
