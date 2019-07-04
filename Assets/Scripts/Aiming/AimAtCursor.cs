using UnityEngine;

namespace Roguelike.Aiming
{
    public class AimAtCursor : AimAtBase
    {
        void FixedUpdate()
        {
            Vector2 myPosition = mainCamera.WorldToViewportPoint(transform.position);
            Vector2 cursorPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);

            Aim(myPosition, cursorPosition);
        }
    }
}
