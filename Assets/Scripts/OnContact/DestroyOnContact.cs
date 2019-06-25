using UnityEngine;

namespace Roguelike.OnContact
{
    public class DestroyOnContact : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other) => Destroy(gameObject);
    }
}
