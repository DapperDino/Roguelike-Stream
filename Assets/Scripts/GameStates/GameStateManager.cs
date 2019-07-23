using Roguelike.Combat;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Roguelike.GameStates
{
    public class GameStateManager : MonoBehaviour
    {
        [Required] [SerializeField] private GameState gameState = null;

        public void SetPlayer(HealthSystem player) => gameState.Player = player;
    }
}
