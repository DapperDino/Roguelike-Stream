using Roguelike.Utilities;
using UnityEngine;

namespace Roguelike.Combat.Enemies
{
    public class EnemyAttackStateBehaviour : SceneLinkedSMB<EnemyLogic>
    {
        public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            monoBehaviour.Attack();
        }
    }
}
