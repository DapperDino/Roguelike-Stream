using UnityEngine;

namespace Roguelike.Actions
{
    public class DestroyAction : MonoBehaviour
    {
        public void Trigger() => Destroy(gameObject);
    }
}
