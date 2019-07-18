using System.Collections.Generic;
using Roguelike.Events.CustomEvents;
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
        [Required] [SerializeField] private WeaponInstanceEvent onWeaponSelected = null;

        private List<WeaponInstance> aquiredWeapons = new List<WeaponInstance>();
        private List<WeaponInstance> currentWeapons = new List<WeaponInstance>();

        private int currentIndex = 0;

        private WeaponInstance CurrentWeapon => currentWeapons[currentIndex];

        public void CheckForWeaponAdd(Item item)
        {
            if (item is WeaponData weapon)
            {
                AddNewWeapon(weapon);
            }
        }

        public void CheckForWeaponRemove(Item item)
        {
            if (item is WeaponData weapon)
            {
                for (int i = 0; i < currentWeapons.Count; i++)
                {
                    if (currentWeapons[i].weaponData == weapon)
                    {
                        currentWeapons[i].weaponLogic.gameObject.SetActive(false);

                        currentWeapons.RemoveAt(i);

                        if (currentWeapons.Count == i)
                        {
                            SetWithIndex(i - 1);
                        }
                        else
                        {
                            SetWithIndex(i);
                        }

                        return;
                    }
                }
            }
        }

        private void AddNewWeapon(WeaponData weaponData)
        {
            WeaponInstance weaponInstance = null;

            for (int i = 0; i < aquiredWeapons.Count; i++)
            {
                if (aquiredWeapons[i].weaponData == weaponData)
                {
                    weaponInstance = aquiredWeapons[i];
                    break;
                }
            }

            if (weaponInstance == null)
            {
                weaponInstance = new WeaponInstance
                {
                    weaponData = weaponData,
                    weaponLogic = Instantiate(weaponData.WeaponLogic, transform).GetComponent<PlayerWeaponLogic>()
                };

                aquiredWeapons.Add(weaponInstance);
            }
            else
            {
                weaponInstance.weaponLogic.gameObject.SetActive(weaponData == CurrentWeapon.weaponData);
                weaponInstance.weaponLogic.transform.SetAsLastSibling();
            }

            currentWeapons.Add(weaponInstance);

            bool isSelectedWeapon = weaponData == CurrentWeapon.weaponData;

            weaponData.WeaponLogic.gameObject.SetActive(isSelectedWeapon);

            onWeaponSelected.Raise(CurrentWeapon);
        }

        private void Update()
        {
            HandleWeaponSwitching();
        }

        private void HandleWeaponSwitching()
        {
            if (currentWeapons.Count < 2) { return; }

            for (int i = 0; i < ExtensionMethods.NumKeys.Length; i++)
            {
                if (Input.GetKeyDown(ExtensionMethods.NumKeys[i]))
                {
                    if (currentWeapons.Count < i + 1) { return; }

                    SwapWithIndex(i);
                }
            }

            float scrollDelta = inputContainer.ScrollInput;

            if (scrollDelta > 0)
            {
                if (currentWeapons.Count - 1 == currentIndex)
                {
                    SwapWithIndex(0);
                }
                else
                {
                    SwapWithIndex(currentIndex + 1);
                }
            }
            else if (scrollDelta < 0)
            {
                if (currentIndex == 0)
                {
                    SwapWithIndex(currentWeapons.Count - 1);
                }
                else
                {
                    SwapWithIndex(currentIndex - 1);
                }
            }
        }

        private void SwapWithIndex(int index)
        {
            CurrentWeapon.weaponLogic.gameObject.SetActive(false);

            SetWithIndex(index);
        }

        private void SetWithIndex(int index)
        {
            currentIndex = index;

            CurrentWeapon.weaponLogic.gameObject.SetActive(true);

            onWeaponSelected.Raise(CurrentWeapon);
        }
    }
}
