using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.StateMachines.StateTransitions
{
    public abstract class StateTransition : MonoBehaviour
    {
        [Required] [SerializeField] private State newState = null;

        public State CheckForTransition(float deltaTime) => CanTransition(deltaTime) ? newState : null;

        protected abstract bool CanTransition(float deltaTime);
    }
}
