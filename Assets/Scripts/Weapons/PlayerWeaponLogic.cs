﻿using Roguelike.Inputs;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace Roguelike.Weapons
{
    public abstract class PlayerWeaponLogic : WeaponLogic
    {
        [SerializeField] private int maxAmmo = 100;

        [Required] [SerializeField] protected InputContainer inputContainer = null;

        public int MaxAmmo => maxAmmo;
        public int CurrentAmmo { get; private set; } = 0;

        protected override void Awake()
        {
            base.Awake();
            CurrentAmmo = maxAmmo;
        }

        public override void Fire()
        {
            float currentTime = Time.time;

            if (CurrentAmmo == 0) { return; }

            if (HandleReload()) { return; }

            if (currentTime - lastFiredTime < 1 / fireRate) { return; }

            CurrentAmmo--;
            remainingClipAmmo--;

            onFire?.Invoke();

            lastFiredTime = currentTime;
        }

        protected override IEnumerator Reload()
        {
            yield return new WaitForSeconds(reloadDuration);

            remainingClipAmmo = CurrentAmmo > clipSize ? clipSize : CurrentAmmo;

            reloadCoroutine = null;
        }
    }
}
