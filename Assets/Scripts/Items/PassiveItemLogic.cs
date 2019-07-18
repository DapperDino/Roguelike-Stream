using UnityEngine;
using UnityEngine.Events;

namespace Roguelike.Items
{
    public class PassiveItemLogic : MonoBehaviour
    {
        [SerializeField] private UnityEvent onFirstPickUp = null;
        [SerializeField] private UnityEvent onEnabled = null;
        [SerializeField] private UnityEvent onDisabled = null;

        private bool hasBeenPickedUp = false;

        private void OnEnable()
        {
            if (!hasBeenPickedUp)
            {
                onFirstPickUp?.Invoke();
                hasBeenPickedUp = true;
            }

            onEnabled?.Invoke();
        }

        private void OnDisable()
        {
            onDisabled?.Invoke();
        }
    }
}