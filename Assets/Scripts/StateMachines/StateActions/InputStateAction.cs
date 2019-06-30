using Roguelike.Inputs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.StateMachines.StateActions
{
    [CreateAssetMenu(fileName = "New Input State Action", menuName = "State Machines/State Actions/Input State Action")]
    public class InputStateAction : StateAction
    {
        [Required] [SerializeField] private InputContainer inputContainer = null;

        public override void Trigger(float deltaTime) => inputContainer.GetInput();

        public override void Exit() => inputContainer.Reset();
    }
}
