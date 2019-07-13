using UnityEngine;

namespace Roguelike.StateMachines.StateTransitions
{
    public class KeyPressStateTransition : StateTransition
    {
        [SerializeField] private KeyCode keyCode = KeyCode.None;

        protected override bool CanTransition(float deltaTime) => Input.GetKeyDown(keyCode);
    }
}

