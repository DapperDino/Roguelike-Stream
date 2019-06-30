using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.StateMachines.StateTransitions
{
    [CreateAssetMenu(fileName = "New State Transition", menuName = "State Machines/State Transition")]
    public abstract class StateTransition : ScriptableObject
    {
        [Required] [SerializeField] private State newState = null;

        public State CheckForTransition(float deltaTime) => CanTransition(deltaTime) ? newState : null;

        protected abstract bool CanTransition(float deltaTime);
    }
}
