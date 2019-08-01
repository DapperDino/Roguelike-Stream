using Cinemachine;
using Roguelike.GameStates;
using Roguelike.Items;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.Characters
{
    public class CharacterSpawner : MonoBehaviour
    {
        [Required] [SerializeField] private Character defaultCharacter = null;
        [Required] [SerializeField] private CinemachineVirtualCamera playerCamera = null;

        private void Start()
        {
            if (GameState.SelectedCharacter == null)
            {
                GameState.SelectedCharacter = defaultCharacter;
            }

            GameObject player = Instantiate(
                GameState.SelectedCharacter.Prefab,
                transform.position,
                Quaternion.identity);

            var inventory = player.GetComponent<Inventory>();

            playerCamera.Follow = player.transform;
            playerCamera.LookAt = player.transform;

            if (!GameState.HasAquiredStartingItems)
            {
                for (int i = 0; i < GameState.SelectedCharacter.StartingItems.Length; i++)
                {
                    inventory.AddItem(GameState.SelectedCharacter.StartingItems[i]);
                }
            }
        }
    }
}
