using Roguelike.Inputs;
using UnityEngine;

namespace Roguelike.Interactables
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private InputContainer inputContainer = null;

        private Interactable currentInteractable = null;

        private void Update()
        {
            if (inputContainer.InteractButtonDown)
            {
                currentInteractable?.Interact(transform.root);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Interactable interactable = other.GetComponent<Interactable>();

            if (interactable == null) { return; }

            if (currentInteractable != null)
            {
                currentInteractable.Exit();
            }

            currentInteractable = interactable;

            currentInteractable.Enter();
        }

        private void OnTriggerExit(Collider other)
        {
            Interactable interactable = other.GetComponent<Interactable>();

            if (interactable == null) { return; }

            if (interactable == currentInteractable)
            {
                currentInteractable.Exit();
                currentInteractable = null;
            }
        }
    }
}
