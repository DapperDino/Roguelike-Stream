using Roguelike.Utilities;
using UnityEngine;

namespace Roguelike.Combat.Enemies
{
    public class EnemyChasingStateBehaviour : SceneLinkedSMB<EnemyLogic>
    {
        public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (monoBehaviour.FindTarget())
            {
                monoBehaviour.EnemyMovementController.MoveTo(monoBehaviour.Target);
            }
        }

        public override void OnSLStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            monoBehaviour.EnemyMovementController.ResetMovement();
        }
    }
}
