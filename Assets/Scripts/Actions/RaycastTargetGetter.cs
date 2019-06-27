using Roguelike.Events.UnityEvents;
using UnityEngine;

namespace Roguelike.Actions
{
    public class RaycastTargetGetter : MonoBehaviour
    {
        [SerializeField] private float range = 5f;
        [SerializeField] private UnityTransformEvent onHit = null;
        [SerializeField] private LayerMask layerMask = new LayerMask();

        public void Trigger()
        {
            if (Physics.Raycast(transform.position, transform.position, out RaycastHit hit, range, layerMask))
            {
                onHit.Invoke(hit.transform);
            }
        }
    }
}
