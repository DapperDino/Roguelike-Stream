using UnityEngine;

namespace Roguelike.Interactables
{
    public abstract class Interactable : MonoBehaviour
    {
        public virtual void Enter() { }
        public abstract void Interact(Transform other);
        public virtual void Exit() { }
    }
}
