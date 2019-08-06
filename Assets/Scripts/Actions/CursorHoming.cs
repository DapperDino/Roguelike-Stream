using UnityEngine;

namespace Roguelike.Actions
{
    public class CursorHoming : HomingBase
    {
        private void Update()
        {
            Vector2 screenPos = mainCamera.WorldToViewportPoint(transform.position);
            Vector2 cursorPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
            
            Move(screenPos, cursorPos);
        }
    }
}