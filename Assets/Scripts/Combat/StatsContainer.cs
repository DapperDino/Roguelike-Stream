using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Combat
{
    [CreateAssetMenu(fileName = "New Stats Container", menuName = "Combat/Stats Container")]
    public class StatsContainer : ScriptableObject
    {
        private Dictionary<StatTypes, float> statValues = new Dictionary<StatTypes, float>();

        public float GetStatValue(StatTypes statType)
        {
            float value = 0;

            if (!statValues.TryGetValue(statType, out value))
            {
                statValues.Add(statType, 0f);
            }
            
            return value;
        }
    }
}