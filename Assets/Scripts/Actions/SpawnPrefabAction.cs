using UnityEngine;

namespace Roguelike.Actions
{
    public class SpawnPrefabAction : MonoBehaviour
    {
        [SerializeField] private GameObject prefabToSpawn = null;

        public void Initialise(GameObject prefab) => prefabToSpawn = prefab;

        public void Trigger()
        {
            if (prefabToSpawn == null) { return; }

            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
    }
}