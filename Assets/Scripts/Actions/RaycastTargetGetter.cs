using Roguelike.Events.UnityEvents;
using UnityEngine;

namespace Roguelike.Actions
{
    public class RaycastTargetGetter : MonoBehaviour
    {
        [SerializeField] private float range = 5f;
        [SerializeField] private int resolution = 1;
        [SerializeField] private float width = 1f;
        [SerializeField] private UnityTransformEvent onHit = null;
        [SerializeField] private LayerMask layerMask = new LayerMask();

        public void Trigger()
        {
            for (int i = 0; i < resolution; i++)
            {
                float offset = 0f;

                if (resolution != 1)
                {
                    offset = i * (width / (resolution - 1));
                }

                offset -= width / 2;

                Vector3 pos = transform.position + transform.TransformDirection(new Vector3(offset, 0f, 0f));

                Debug.DrawRay(pos, transform.forward * 5, Color.red, 1f);

                if (Physics.Raycast(pos, transform.forward, out RaycastHit hit, range, layerMask))
                {
                    onHit?.Invoke(hit.transform);
                }
            }
        }
    }
}
