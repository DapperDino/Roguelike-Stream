using Roguelike.Combat;
using UnityEngine;

namespace Roguelike.Aiming
{
    public class AimAtTarget : AimAtBase
    {
        private Transform target = null;

        public void SetTarget(Transform target)
        {
            if (target != null)
            {
                HealthSystem damageable = target.GetComponent<HealthSystem>();

                if (damageable != null)
                {
                    this.target = damageable.TargetPoint;
                    return;
                }

                this.target = target;
                return;
            }

            this.target = null;
        }

        void FixedUpdate()
        {
            if (target == null) { return; }

            Vector2 myPosition = new Vector2(transform.position.x, transform.position.z);
            Vector2 targetPosition = new Vector2(target.position.x, target.position.z);

            Aim(myPosition, targetPosition);
        }
    }
}
