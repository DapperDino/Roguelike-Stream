using Roguelike.Inputs;
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

        private void Start() => characterController = GetComponent<CharacterController>();

        private void Update() => Move();

        private void Move()
        {
            if (characterController.isGrounded && velocityY < 0f) { velocityY = 0f; }

            velocityY += gravity * Time.deltaTime;

            Vector2 movementInput = inputContainer.MovementInput;

            Vector3 movementDirection = new Vector3(movementInput.x, 0f, movementInput.y);

            movementDirection.Normalize();

            Vector3 velocity = Vector3.up * velocityY + movementDirection * movementSpeed;

            characterController.Move(velocity * Time.deltaTime);
        }
    }
}
