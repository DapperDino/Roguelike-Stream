using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Roguelike.Weapons
{
    public class WeaponLogic : MonoBehaviour
    {

        [SerializeField] protected int clipSize = 10;
        [SerializeField] protected float reloadDuration = 1f;
        [SerializeField] protected float fireRate = 1f;
        [SerializeField] protected UnityEvent onFire = null;

        protected Coroutine reloadCoroutine = null;
        protected float lastFiredTime = 0;
        protected int remainingClipAmmo = 0;

        protected virtual void Awake() => remainingClipAmmo = clipSize;

        public virtual void Fire()
        {
            float currentTime = Time.time;

            if (HandleReload()) { return; }

            if (currentTime - lastFiredTime < 1 / fireRate) { return; }

            remainingClipAmmo--;

            onFire?.Invoke();

            lastFiredTime = currentTime;
        }

        protected bool HandleReload()
        {
            if (remainingClipAmmo == 0)
            {
                if (reloadCoroutine == null)
                {
                    reloadCoroutine = StartCoroutine(Reload());
                }
                return true;
            }

            return false;
        }

        protected virtual IEnumerator Reload()
        {
            yield return new WaitForSeconds(reloadDuration);

            remainingClipAmmo = clipSize;

            reloadCoroutine = null;
        }
    }
}
