using UnityEngine;

namespace Roguelike.Combat.Enemies
{
    public class SpawnDelay : MonoBehaviour
    {
        private GameObject prefab = null;

        public void Initialise(GameObject prefab)
        {
            this.prefab = prefab;
        }

        public void Spawn()
        {
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}