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
        [SerializeField] private float aggroRange = 20f;
        [SerializeField] private float attackRange = 15f;
        [Required] [SerializeField] private GameState gameState = null;
        [Required] [SerializeField] private AimAtTarget aimAtTarget = null;
        [SerializeField] private UnityEvent onFire = null;

        private Animator animator = null;
        private bool isAggrod = false;
        private static readonly int hashAggrod = Animator.StringToHash("Aggrod");
        private static readonly int hashInFiringRange = Animator.StringToHash("InFiringRange");

        public Transform Target { get; private set; } = null;
        public EnemyMovementController EnemyMovementController { get; private set; } = null;

        private void Start()
        {
            animator = GetComponent<Animator>();
            EnemyMovementController = GetComponent<EnemyMovementController>();

            SceneLinkedSMB<EnemyLogic>.Initialise(animator, this);

            SetTarget(gameState.Player.transform);
        }

        private void Update()
        {
            if (isAggrod)
            {
                animator.SetBool(hashAggrod, true);
            }
            else
            {
                animator.SetBool(hashAggrod, IsInRange(aggroRange));
            }

            animator.SetBool(hashInFiringRange, IsInRange(attackRange));
        }

        public void SetTarget(Transform target)
        {
            Target = target;
            aimAtTarget.SetTarget(Target);
        }

        public void Fire()
        {
            onFire?.Invoke();
        }

        private bool IsInRange(float range)
        {
            if (Target == null) { return false; }

            return (transform.position - Target.position).sqrMagnitude < range * range;
        }
    }
}

