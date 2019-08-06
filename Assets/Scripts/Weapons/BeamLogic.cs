using UnityEngine;
using UnityEngine.Events;

namespace Roguelike.Weapons
{
    public class BeamLogic : PlayerWeaponLogic
    {
        [SerializeField] private float requiredWindUpTime = 0;
        [SerializeField] private UnityEvent onStartBeaming, onEndBeaming, onMouseDown, onMouseUp = null;

        private float currentWindUpTime = 0;
        private bool isBeaming = false;

        private void Update()
        {
            if (inputContainer.FireButton)
            {
                if (currentWindUpTime < requiredWindUpTime)
                {
                    currentWindUpTime += Time.deltaTime;
                }
                else
                {
                    if (!isBeaming)
                    {
                        onStartBeaming?.Invoke();
                        isBeaming = true;
                    }

                    Fire();
                }
            }
            else
            {
                if (isBeaming)
                {
                    onEndBeaming?.Invoke();
                    isBeaming = false;
                }

                currentWindUpTime = 0;
            }

            if (inputContainer.FireButtonDown) { onMouseDown?.Invoke(); }
            if (inputContainer.FireButtonUp) { onMouseUp?.Invoke(); }
        }
    }
}
