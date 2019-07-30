using UnityEngine;

namespace Roguelike.Interactables
{
    public abstract class Interactable : MonoBehaviour, IInteractable
    {
        public Interactor Interactor { get; set; }

        public abstract void Interact(GameObject other);

        private void OnDisable() { if (Interactor != null) { Interactor.RemoveInteractable(this); } }
    }
}
