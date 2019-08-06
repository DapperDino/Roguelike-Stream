using UnityEngine;

namespace Roguelike.Utilities
{
    public class FaceCamera : MonoBehaviour
    {
        private Camera mainCamera = null;

        private void Start() => mainCamera = Camera.main;

        private void LateUpdate()
        {
            transform.LookAt(
                transform.position + mainCamera.transform.rotation * Vector3.forward,
                mainCamera.transform.rotation * Vector3.up);
        }
    }
}
