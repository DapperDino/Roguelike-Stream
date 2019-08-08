using Roguelike.Actions;
using Roguelike.LevelGeneration;
using Roguelike.Rooms;
using Roguelike.Utilities;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace Roguelike.Combat.Enemies
{
    [RequireComponent(typeof(Room))]
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float radius = 12;
        [Required] [SerializeField] private GameObject enemySpawnPrefab = null;

        public void Spawn()
        {
            LevelSettings levelSettings = GetComponent<Room>().LevelSettings;
            int enemyCount = levelSettings.EnemyCount;

            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 randomPosition = transform.position + (Random.insideUnitSphere * radius);

                if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, radius, NavMesh.AllAreas))
                {
                    Instantiate(enemySpawnPrefab, hit.position, Quaternion.identity)
                        .GetComponent<SpawnPrefabAction>().Initialise(levelSettings.EnemyPicker.GetRandom().gameObject);
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
