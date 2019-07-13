using Roguelike.Combat;
using UnityEngine;

namespace Roguelike
{
    [CreateAssetMenu(fileName = "New Game State", menuName = "Game State")]
    public class GameState : ScriptableObject
    {
        public Damageable Player { get; set; }

        private float gameStartTime = 0f;

        public float GameDuration => Time.time - gameStartTime;

        public void Reset()
        {
            gameStartTime = Time.time;
            Player = null;
        }
    }
}
