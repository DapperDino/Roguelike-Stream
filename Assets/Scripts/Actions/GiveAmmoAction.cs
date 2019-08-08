using System.Collections;
using System.Collections.Generic;
using Roguelike.Weapons;
using UnityEngine;

namespace Roguelike.Actions
{
    public class GiveAmmoAction : MonoBehaviour
    {
        [SerializeField] private int ammoToAdd = 100;

        public void Trigger()
        {
            var weapons = transform.root.GetComponentsInChildren<PlayerWeaponLogic>();

            for (int i = 0; i < weapons.Length; i++)
            {
                if (weapons[i].gameObject.activeInHierarchy)
                {
                    weapons[i].AddAmmo(ammoToAdd);
                    return;
                }
            }
        }
    }
}
