using UnityEngine;

namespace Roguelike.Player
{
    public class PlayerMovement : MonoBehaviour
    {
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

            Vector3 movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

            movementDirection.Normalize();

            Vector3 velocity = Vector3.up * velocityY + movementDirection * movementSpeed;

            characterController.Move(velocity * Time.deltaTime);
        }
    }
}
