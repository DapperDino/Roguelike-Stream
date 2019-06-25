using UnityEngine;

namespace Roguelike.Utilities
{
    public class TransformMovement : MonoBehaviour
    {
        [SerializeField] private Vector3 velocity = new Vector3();

        public void Initialise(Vector3 velocity) => this.velocity = velocity;

        private void Update() => transform.Translate(velocity * Time.deltaTime, Space.World);
    }
}