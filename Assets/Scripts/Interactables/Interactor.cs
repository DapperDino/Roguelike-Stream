using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Interactables
{
    public class Interactor : MonoBehaviour
    {
        [Required] [SerializeField] private GameObject entity = null;

        private List<IInteractable> interactables = new List<IInteractable>();

        private void Update() => CheckForInteraction();

        private void OnTriggerEnter(Collider other)
        {
            var interactable = other.GetComponent<IInteractable>();

            if (interactable == null) { return; }

            AddInteractable(interactable);
        }

        private void OnTriggerExit(Collider other)
        {
            var interactable = other.GetComponent<IInteractable>();

            if (interactable == null) { return; }

            RemoveInteractable(interactable);
        }

        private void CheckForInteraction()
        {
            if (interactables.Count == 0) { return; }

            if (!Input.GetKeyDown(KeyCode.E)) { return; }

            interactables[0].Interact(entity);
        }

        private void AddInteractable(IInteractable interactable)
        {
            interactables.Add(interactable);

            interactable.Interactor = this;
        }

        public void RemoveInteractable(IInteractable interactable)
        {
            if (!interactables.Contains(interactable)) { return; }

            interactables.Remove(interactable);

            interactable.Interactor = null;
        }
    }
}
