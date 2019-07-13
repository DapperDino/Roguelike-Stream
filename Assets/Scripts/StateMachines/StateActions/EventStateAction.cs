using Roguelike.Events.CustomEvents;
using UnityEngine;

namespace Roguelike.StateMachines.StateActions
{
    public class EventStateAction : StateAction
    {
        [SerializeField] private VoidEvent eventOnEnter, eventOnExit = null;

        public override void Enter() => eventOnEnter?.Raise();
        public override void Exit() => eventOnExit?.Raise();
    }
}
