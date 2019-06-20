using UnityEngine;

namespace Roguelike.Interactables
{
    public abstract class Interactable : MonoBehaviour
    {
        private static Interactable currentInteractable;

        private void Update()
        {
            if (currentInteractable == this)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Interact();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (currentInteractable == null)
            {
                currentInteractable = this;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (currentInteractable == this)
            {
                currentInteractable = null;
            }
        }

        protected abstract void EnterInteractable();
        protected abstract void Interact();
        protected abstract void ExitInteractable();
    }
}
