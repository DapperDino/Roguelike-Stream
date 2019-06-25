using UnityEngine;
using UnityEngine.Events;

namespace Roguelike.Weapons
{
    public class BeamLogic : WeaponLogic
    {
        [SerializeField] private float requiredWindUpTime = 0;
        [SerializeField] private UnityEvent onStartBeaming, onEndBeaming = null;

        private float currentWindUpTime = 0;
        private bool isBeaming = false;

        private void Update()
        {
            if (Input.GetMouseButton(0))
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
        }
    }
}
