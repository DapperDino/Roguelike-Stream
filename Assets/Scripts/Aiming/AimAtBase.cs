using UnityEngine;

namespace Roguelike.Aiming
{
    public class AimAtBase : MonoBehaviour
    {
        protected Camera mainCamera = null;

        private void Start() => mainCamera = Camera.main;

        protected void Aim(Vector2 myPosition, Vector2 targetPosition)
        {
            transform.rotation = Quaternion.Euler(new Vector3(
                0f,
                -Mathf.Atan2(myPosition.y - targetPosition.y, myPosition.x - targetPosition.x) * Mathf.Rad2Deg,
                0f));
        }
    }
}
