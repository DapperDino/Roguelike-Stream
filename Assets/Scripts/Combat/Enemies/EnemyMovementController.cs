using UnityEngine;
using UnityEngine.AI;

namespace Roguelike.Combat.Enemies
{
    public class EnemyMovementController : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent = null;

        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.enabled = true;
        }

        public void MoveTo(Transform target)
        {
            navMeshAgent.SetDestination(target.position);
        }

        public void ResetMovement()
        {
            navMeshAgent.ResetPath();
        }
    }
}

