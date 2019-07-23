using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Roguelike.Combat.Stats
{
    public class StatsContainer : MonoBehaviour
    {
        [SerializeField] private UnityEvent onStatValuesChanged = null;

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


        public void ChangeStatValue(StatTypes statType, float modifier)
        {
            if (!statValues.ContainsKey(statType))
            {
                statValues.Add(statType, modifier);
            }
            else
            {
                statValues[statType] += modifier;
            }

            onStatValuesChanged.Invoke();
        }
    }
}