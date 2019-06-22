using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Roguelike.Items
{
    [Serializable]
    public class QualityHandler
    {
        [SerializeField] private List<QualityChance> qualityChances = new List<QualityChance>();

        public Quality GetRandomQuality()
        {
            float count = 0;

            foreach (QualityChance qualityChance in qualityChances)
            {
                count += qualityChance.Chance;
            }

            float roll = UnityEngine.Random.Range(0, count);

            foreach (QualityChance qualityChance in qualityChances)
            {
                if (roll <= qualityChance.Chance)
                {
                    return qualityChance.Quality;
                }

                roll -= qualityChance.Chance;
            }

            return qualityChances.First().Quality;
        }
    }

    [Serializable]
    public class QualityChance
    {
        [Required] [SerializeField] private Quality quality;
        [SerializeField] [Range(0f, 100f)] private float chance;

        public Quality Quality => quality;
        public float Chance => chance;
    }
}