using Roguelike.Events.UnityEvents;
using UnityEngine;

namespace Roguelike.Combat
{
    public class TargetGetter : MonoBehaviour
    {
        [SerializeField] private float range = 5f;
        [SerializeField] private LayerMask layerMask = new LayerMask();
        [SerializeField] private UnityTransformEvent onNewTargetFound = null;
        [SerializeField] private UnityTransformEvent onTargetLost = null;

        private Transform currentTarget = null;

        private void Update()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, range, layerMask);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].transform != currentTarget)
                {
                    currentTarget = colliders[i].transform;
                    onNewTargetFound?.Invoke(currentTarget);
                    return;
                }
            }

            if (colliders.Length > 0) { return; }
            
            if (currentTarget != null)
            {
                onTargetLost?.Invoke(currentTarget);
                currentTarget = null;
            }
        }
    }
}