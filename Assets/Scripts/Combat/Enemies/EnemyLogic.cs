using Roguelike.Aiming;
using Roguelike.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Roguelike.Combat.Enemies
{
    [RequireComponent(typeof(Animator), typeof(EnemyMovementController))]
    public class EnemyLogic : MonoBehaviour
    {
        [SerializeField] private float attackRange = 15f;
        [SerializeField] private UnityEvent onAttack = null;

        private Animator animator = null;
        private static readonly int hashAggrod = Animator.StringToHash("Aggrod");
        private static readonly int hashInAttackRange = Animator.StringToHash("InAttackRange");

        public EnemyMovementController EnemyMovementController { get; private set; } = null;

        public Transform Target { get; private set; }

        private void Start()
        {
            animator = GetComponent<Animator>();
            EnemyMovementController = GetComponent<EnemyMovementController>();

            SceneLinkedSMB<EnemyLogic>.Initialise(animator, this);
        }

        private void Update()
        {
            animator.SetBool(hashAggrod, Target != null);

            animator.SetBool(hashInAttackRange, IsInRange(attackRange));
        }

        public void SetTarget(Transform target) => Target = target;

        public void ClearTarget() => Target = null;

        public void Attack() => onAttack?.Invoke();

        private bool IsInRange(float range)
        {
            if (Target == null) { return false; }

            return (transform.position - Target.position).sqrMagnitude < range * range;
        }
    }
}

