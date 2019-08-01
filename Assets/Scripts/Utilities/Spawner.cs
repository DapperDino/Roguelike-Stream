using System.Collections.Generic;
using Roguelike.Actions;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace Roguelike.Utilities
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float radius = 10;
        [Required] [SerializeField] private GameObject enemySpawnPrefab = null;
        [SerializeField] private List<GameObject> objectsToSpawn = new List<GameObject>();

        public void Spawn()
        {
            for (int i = 0; i < objectsToSpawn.Count; i++)
            {
                Vector3 randomPosition = transform.position + (Random.insideUnitSphere * radius);

                if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, radius, NavMesh.AllAreas))
                {
                    Instantiate(enemySpawnPrefab, hit.position, Quaternion.identity)
                        .GetComponent<SpawnPrefabAction>().Initialise(objectsToSpawn[i]);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
