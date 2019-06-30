using Roguelike.Events.CustomEvents;
using UnityEngine;

namespace Roguelike.StateMachines.StateActions
{
    [CreateAssetMenu(fileName = "New Event State Action", menuName = "State Machines/State Actions/Event State Action")]
    public class EventStateAction : StateAction
    {
        [SerializeField] private VoidEvent eventOnEnter, eventOnExit = null;

        public override void Enter() => eventOnEnter?.Raise();
        public override void Exit() => eventOnExit?.Raise();
    }
}
