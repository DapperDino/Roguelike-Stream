using Roguelike.Inputs;
using UnityEngine;

namespace Roguelike.Interactables
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] private InputContainer[] inputContainers = new InputContainer[0];

        private static Interactable currentInteractable = null;

        protected Transform Player { get; private set; } = null;

        private void Update()
        {
            if (currentInteractable == this)
            {
                foreach (InputContainer inputContainer in inputContainers)
                {
                    if (inputContainer.InteractButtonDown)
                    {
                        Interact();
                        return;
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Player = other.transform;

            if (currentInteractable != null)
            {
                currentInteractable.Exit();
            }

            currentInteractable = this;

            Enter();
        }

        private void OnTriggerExit(Collider other)
        {
            Player = null;

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

        protected virtual void Enter() { }
        protected abstract void Interact();
        protected virtual void Exit() { }
    }
}
