using Roguelike.StateMachines.StateActions;
using Roguelike.StateMachines.StateTransitions;
using UnityEngine;

namespace Roguelike.StateMachines
{
    [CreateAssetMenu(fileName = "New State", menuName = "State Machines/State")]
    public class State : ScriptableObject
    {
        [SerializeField] private StateAction[] stateActions = new StateAction[0];
        [SerializeField] private StateTransition[] stateTransitions = new StateTransition[0];

        public void Enter()
        {
            foreach (StateAction stateAction in stateActions)
            {
                stateAction.Enter();
            }
        }

        public void Tick(float deltaTime)
        {
            foreach (StateAction stateAction in stateActions)
            {
                stateAction.Trigger(deltaTime);
            }
        }

        public void Exit()
        {
            foreach (StateAction stateAction in stateActions)
            {
                stateAction.Exit();
            }
        }

        public State CheckForTransitions(float deltaTime)
        {
            foreach (StateTransition stateTransition in stateTransitions)
            {
                State newState = stateTransition.CheckForTransition(deltaTime);

                if (newState != null) { return newState; }
            }

            return null;
        }
    }
}
