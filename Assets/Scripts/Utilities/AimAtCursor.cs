using UnityEngine;

namespace Roguelike.Utilities
{
    public class AimAtCursor : MonoBehaviour
    {
        private Camera mainCamera = null;

        private void Start() => mainCamera = Camera.main;

        void FixedUpdate()
        {
            Vector2 screenPos = mainCamera.WorldToViewportPoint(transform.position);
            Vector2 cursorPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);

            transform.rotation = Quaternion.Euler(new Vector3(
                0f,
                -Mathf.Atan2(screenPos.y - cursorPos.y, screenPos.x - cursorPos.x) * Mathf.Rad2Deg,
                0f));
        }
    }
}
