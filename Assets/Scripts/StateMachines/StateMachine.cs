using UnityEngine;

namespace Roguelike.StateMachines
{
    [CreateAssetMenu(fileName = "New State Machine", menuName = "State Machines/State Machine")]
    public class StateMachine : ScriptableObject
    {
        private State currentState = null;

        public void Tick()
        {
            float deltaTime = Time.deltaTime;

            currentState?.Tick(deltaTime);

            State newState = currentState.CheckForTransitions(deltaTime);

            if (newState != null) { SetState(newState); }
        }

        public void SetState(State state)
        {
            currentState.Exit();
            currentState = state;
            currentState.Enter();
        }
    }
}
