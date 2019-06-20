using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;

    private CharacterController characterController = null;

    private void Start() => characterController = GetComponent<CharacterController>();

    private void Update() => Move();

    private void Move()
    {
        Vector3 movementDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        movementDirection.Normalize();

        characterController.Move(movementDirection * movementSpeed * Time.deltaTime);
    }
}
