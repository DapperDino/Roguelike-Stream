using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Roguelike.Utilities
{
    [Serializable]
    public class ChancePicker<T>
    {
        [SerializeField] private List<Chances<T>> chances = new List<Chances<T>>();

        public T GetRandom()
        {
            float count = 0;

            foreach (Chances<T> chance in chances)
            {
                count += chance.Chance;
            }

            float roll = UnityEngine.Random.Range(0, count);

            foreach (Chances<T> chance in chances)
            {
                if (roll <= chance.Chance)
                {
                    return chance.ChanceType;
                }

                roll -= chance.Chance;
            }

            return chances.First().ChanceType;
        }
    }

    [Serializable]
    public class Chances<T>
    {
        [Required] [SerializeField] private T chanceType;
        [SerializeField] [Range(0f, 100f)] private float chance;

        public T ChanceType => chanceType;
        public float Chance => chance;
    }
}