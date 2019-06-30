using UnityEngine;

namespace Roguelike.StateMachines.StateActions
{
    [CreateAssetMenu(fileName = "New Time Scale State Action", menuName = "State Machines/State Actions/Time Scale State Action")]
    public class TimeScaleStateAction : StateAction
    {
        [SerializeField] private int timeScaleOnEnter = 1;
        [SerializeField] private int timeScaleOnExit = 1;

        public override void Enter() => Time.timeScale = timeScaleOnEnter;
        public override void Exit() => Time.timeScale = timeScaleOnExit;
    }
}
