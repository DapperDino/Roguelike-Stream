using UnityEngine;

namespace Roguelike.Interactables
{
    public abstract class Interactable : MonoBehaviour
    {
        private static Interactable currentInteractable = null;

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
            if (currentInteractable != null)
            {
                currentInteractable.Exit();
            }

            currentInteractable = this;
            Enter();
        }

        private void OnTriggerExit(Collider other)
        {
            if (currentInteractable == this)
            {
                currentInteractable = null;
                Exit();
            }
        }

        private void OnDisable()
        {
            if (currentInteractable == this)
            {
                currentInteractable = null;
                Exit();
            }
        }

        protected abstract void Enter();
        protected abstract void Interact();
        protected abstract void Exit();
    }
}
