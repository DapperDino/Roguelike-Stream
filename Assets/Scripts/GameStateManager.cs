using Roguelike.Combat;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike
{
    public class GameStateManager : MonoBehaviour
    {
        [Required] [SerializeField] private GameState gameState = null;

        public void SetPlayer(Damageable player) => gameState.Player = player;
    }
}
