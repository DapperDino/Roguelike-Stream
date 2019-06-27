using Roguelike.Events.UnityEvents;
using UnityEngine;

namespace Roguelike.Actions
{
    public class OverlapTrigger : MonoBehaviour
    {
        [SerializeField] private UnityTransformEvent onTrigger = null;
        [SerializeField] private LayerMask layerMask = new LayerMask();

        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & layerMask) != 0)
            {
                onTrigger.Invoke(other.transform);
            }
        }
    }
}
