using UnityEngine;

namespace Roguelike.Interactables
{
    public interface IInteractable
    {
        Interactor Interactor { get; set; }
        void Interact(GameObject other);
    }
}
