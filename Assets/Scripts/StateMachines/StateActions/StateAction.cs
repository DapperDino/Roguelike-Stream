using UnityEngine;

namespace Roguelike.StateMachines.StateActions
{
    public abstract class StateAction : ScriptableObject
    {
        public virtual void Enter() { }
        public virtual void Trigger(float deltaTime) { }
        public virtual void Exit() { }
    }
}
