using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.StateMachines
{
    public class StateManager : MonoBehaviour
    {
        [Required] [SerializeField] private StateMachine stateMachine = null;
        [Required] [SerializeField] private State initialState = null;

        private void Start() => stateMachine.SetState(initialState);

        private void Update() => stateMachine?.Tick();
    }
}
