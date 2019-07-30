using UnityEngine;
using UnityEngine.Events;

namespace Roguelike.Interactables
{
    public class EventInteractable : Interactable
    {
        [SerializeField] private UnityEvent onInteract = null;

        public override void Interact(GameObject other)
        {
            onInteract?.Invoke();
        }
    }
}