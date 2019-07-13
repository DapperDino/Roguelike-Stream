using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.StateMachines
{
    public class StateMachine : MonoBehaviour
    {
        [Required] [SerializeField] private State startingState = null;

        private State currentState = null;

        private void Start() => SetState(startingState);

        public void Update()
        {
            float deltaTime = Time.deltaTime;

            currentState?.Tick(deltaTime);

            State newState = currentState.CheckForTransitions(deltaTime);

            if (newState != null) { SetState(newState); }
        }

        public void SetState(State state)
        {
            currentState?.Exit();
            currentState = state;
            currentState?.Enter();
        }
    }
}
