using System;
using Roguelike.GameStates;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Roguelike.Combat
{
    public class GameOverUI : MonoBehaviour
    {
        [Required] [SerializeField] private TextMeshProUGUI characterNameText = null;
        [Required] [SerializeField] private TextMeshProUGUI survivalTimeText = null;
        [Required] [SerializeField] private TextMeshProUGUI killCountText = null;

        public void SetData()
        {
            characterNameText.text = GameState.SelectedCharacter.Name;

            TimeSpan t = TimeSpan.FromSeconds(Time.time - GameState.GameStartTime);
            survivalTimeText.text = $"{t.Hours}:{t.Minutes}:{t.Seconds}";

            //killCountText.text = GameState.TotalKills.ToString();

            GameState.Reset();
        }
    }
}
