using Roguelike.Utilities;
using UnityEngine;

namespace Roguelike.Combat.Enemies
{
    public class EnemyRangedAttackStateBehaviour : SceneLinkedSMB<EnemyLogic>
    {
        public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            monoBehaviour.Fire();
        }
    }
}
