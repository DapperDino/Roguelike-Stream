﻿using Roguelike.Combat;
using UnityEngine;

namespace Roguelike.GameStates
{
    [CreateAssetMenu(fileName = "New Game State", menuName = "Game State")]
    public class GameState : ScriptableObject
    {
        public HealthSystem Player { get; set; }

        private float gameStartTime = 0f;

        public float GameDuration => Time.time - gameStartTime;

        public void Reset()
        {
            gameStartTime = Time.time;
            Player = null;
        }
    }
}
