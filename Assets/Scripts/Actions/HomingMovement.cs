using UnityEngine;

namespace Roguelike.Actions
{
    [RequireComponent(typeof(Rigidbody))]
    public class HomingMovement : MonoBehaviour
    {
        [SerializeField] private float targetSpeed = 1f;
        [SerializeField] private float smoothing = 0f;

        private float smoothSpeed = 0f;
        private float currentSpeed = 0f;

        private Camera mainCamera = null;
        private Rigidbody rb = null;

        public void SetSpeed(float speed) => targetSpeed = speed;

        private void Start()
        {
            mainCamera = Camera.main;

            rb = GetComponent<Rigidbody>();

            currentSpeed = targetSpeed;
        }

        private void Update()
        {
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref smoothSpeed, smoothing);

            Vector2 screenPos = mainCamera.WorldToViewportPoint(transform.position);
            Vector2 cursorPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);

            Vector2 direction = (cursorPos - screenPos).normalized;

            rb.velocity = Vector3.Lerp(
                rb.velocity,
                new Vector3(direction.x, 0f, direction.y) * currentSpeed,
                smoothing);
        }

    }
}