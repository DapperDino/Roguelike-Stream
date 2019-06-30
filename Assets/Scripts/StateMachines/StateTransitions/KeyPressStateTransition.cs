using UnityEngine;

namespace Roguelike.StateMachines.StateTransitions
{
    [CreateAssetMenu(fileName = "New Key Press State Transition", menuName = "State Machines/State Transitions/Key Press State Transition")]
    public class KeyPressStateTransition : StateTransition
    {
        [SerializeField] private KeyCode keyCode = KeyCode.None;

        protected override bool CanTransition(float deltaTime) => Input.GetKeyDown(keyCode);
    }
}

