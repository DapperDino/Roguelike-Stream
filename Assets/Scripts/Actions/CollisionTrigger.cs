using Roguelike.Events.UnityEvents;
using UnityEngine;

namespace Roguelike.Actions
{
    public class CollisionTrigger : MonoBehaviour
    {
        [SerializeField] private UnityTransformEvent onCollision = null;
        [SerializeField] private LayerMask layerMask = new LayerMask();

        private void OnCollisionEnter(Collision collision)
        {
            if (((1 << collision.gameObject.layer) & layerMask) != 0)
            {
                onCollision.Invoke(collision.transform);
            }
        }
    }
}
