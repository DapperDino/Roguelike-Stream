using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Roguelike.Weapons
{
    public abstract class WeaponLogic : MonoBehaviour
    {
        [SerializeField] private int maxAmmo = 100;
        [SerializeField] private int clipSize = 10;
        [SerializeField] private float reloadDuration = 1f;
        [SerializeField] private float fireRate = 1f;
        [SerializeField] private UnityEvent onFire = null;

        private Coroutine reloadCoroutine = null;

        private float lastFiredTime = 0;
        private int currentAmmo = 0;
        private int remainingClipAmmo = 0;

        private void Start()
        {
            currentAmmo = maxAmmo;
            remainingClipAmmo = clipSize;
        }

        protected void Fire()
        {
            float currentTime = Time.time;

            if (currentAmmo == 0) { return; }

            if (remainingClipAmmo == 0)
            {
                if (reloadCoroutine == null)
                {
                    reloadCoroutine = StartCoroutine(Reload());
                }
                return;
            }

            if (currentTime - lastFiredTime < 1 / fireRate) { return; }

            currentAmmo--;
            remainingClipAmmo--;

            onFire?.Invoke();

            lastFiredTime = currentTime;
        }

        private IEnumerator Reload()
        {
            yield return new WaitForSeconds(reloadDuration);

            remainingClipAmmo = currentAmmo > clipSize ? clipSize : currentAmmo;

            reloadCoroutine = null;
        }
    }
}
