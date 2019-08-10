using Roguelike.Combat.Stats;
using Roguelike.Inputs;
using Roguelike.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Movement
{
    public class MovementController : MonoBehaviour
    {
        [Required] [SerializeField] private InputContainer inputContainer = null;
        [SerializeField] private float movementSpeed = 5f;

        private float velocityY = 0f;
        private readonly float gravity = Physics.gravity.y;
        private CharacterController characterController = null;
        private StatsContainer statsContainer = null;

        private float MovementSpeed
        {
            get
            {
                float speedMultipler = statsContainer == null ? 0 : statsContainer.GetStatValue(StatTypes.MoveSpeedMultiplier);
                return movementSpeed * (1 + speedMultipler);
            }
        }

        private void Start()
        {
            characterController = GetComponent<CharacterController>();
            statsContainer = GetComponent<StatsContainer>();
        }

        private void Update() => Move();

        public void ResetPos()
        {
            transform.MoveCharacterController(new Vector3(0f, 0.5f, 0f));
        }

        private void Move()
        {
            if (characterController.isGrounded && velocityY < 0f) { velocityY = 0f; }

            velocityY += gravity * Time.deltaTime;

            Vector2 movementInput = inputContainer.MovementInput;

            Vector3 movementDirection = new Vector3(movementInput.x, 0f, movementInput.y);

            movementDirection.Normalize();

            Vector3 velocity = Vector3.up * velocityY + movementDirection * MovementSpeed;

            characterController.Move(velocity * Time.deltaTime);
        }
    }
}
