using UnityEngine;

namespace Roguelike.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private string weaponName = "New Weapon Name";
        [SerializeField] private int maxAmmo = 50;
        [SerializeField] private GameObject weaponModel = null;

        private int currentAmmo;

        private void Start()
        {
            currentAmmo = maxAmmo;
        }

        public void Fire()
        {
            currentAmmo--;
            Debug.Log(currentAmmo);
        }
    }
}
