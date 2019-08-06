using UnityEngine;

namespace Roguelike.Actions
{
    [RequireComponent(typeof(Rigidbody))]
    public class HomingBase : MonoBehaviour
    {
        [SerializeField] private float targetSpeed = 1f;
        [SerializeField] private float smoothing = 0f;

        private float smoothSpeed = 0f;
        private float currentSpeed = 0f;

        protected Camera mainCamera = null;
        private Rigidbody rb = null;

        public void SetSpeed(float speed) => targetSpeed = speed;

        private void Start()
        {
            mainCamera = Camera.main;

            rb = GetComponent<Rigidbody>();

            currentSpeed = targetSpeed;

            rb.velocity = Vector3.Lerp(
                rb.velocity,
                transform.forward * currentSpeed,
                1);
        }

        protected void Move(Vector2 myPos, Vector2 targetPos)
        {
            if (targetPos == Vector2.zero) { return; }

            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref smoothSpeed, smoothing);      

            Vector2 direction = (targetPos - myPos).normalized;

            rb.velocity = Vector3.Lerp(
                rb.velocity,
                new Vector3(direction.x, 0f, direction.y) * currentSpeed,
                smoothing);
        }
    }
}