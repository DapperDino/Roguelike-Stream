using UnityEngine;
using UnityEngine.Events;

namespace Roguelike.Weapons
{
    public abstract class WeaponLogic : MonoBehaviour
    {
        [SerializeField] private int maxAmmo = 100;
        [SerializeField] private float fireRate = 1;
        [SerializeField] private UnityEvent onFire = null;

        private float lastFiredTime = 0;
        private int currentAmmo = 0;

        private void Start()
        {
            currentAmmo = maxAmmo;
        }

        protected void Fire()
        {
            float currentTime = Time.time;

            if (currentAmmo == 0) { return; }

            if (currentTime - lastFiredTime < 1 / fireRate) { return; }

            currentAmmo--;

            onFire?.Invoke();

            lastFiredTime = currentTime;
        }
    }
}
