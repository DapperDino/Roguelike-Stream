using UnityEngine;

namespace Roguelike.Actions
{
    public class TargetHoming : HomingBase
    {
        private Transform target = null;

        public void SetTarget(Transform target) => this.target = target;
        public void ClearTarget() { target = null; }

        private void Update()
        {
            if (target == null) { Move(Vector2.zero, Vector2.zero); return; }

            Vector2 myPos = mainCamera.WorldToViewportPoint(transform.position);
            Vector2 targetPos = mainCamera.WorldToViewportPoint(target.position);

            Move(myPos, targetPos);
        }
    }
}