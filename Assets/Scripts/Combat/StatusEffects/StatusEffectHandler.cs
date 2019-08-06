using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Combat.StatusEffects
{
    public class StatusEffectHandler : MonoBehaviour
    {
        private List<StatusEffect> statusEffects = new List<StatusEffect>();

        private void Update()
        {
            float currentTime = Time.time;

            for (int i = statusEffects.Count - 1; i >= 0; i--)
            {
                if (statusEffects[i].ShouldTick(currentTime))
                {
                    statusEffects[i].Tick();

                    if (statusEffects[i].ShouldRemove)
                    {
                        RemoveEffect(statusEffects[i]);
                    }
                }
            }
        }

        public void ApplyEffect(StatusEffect statusEffect)
        {
            for (int i = 0; i < statusEffects.Count; i++)
            {
                if (statusEffects[i].StatusEffectType == statusEffect.StatusEffectType)
                {
                    RemoveEffect(statusEffects[i]);
                    break;
                }
            }

            AddEffect(statusEffect);
        }

        private void AddEffect(StatusEffect statusEffect)
        {
            statusEffects.Add(statusEffect);
            statusEffect.Initialise(gameObject);
        }

        private void RemoveEffect(StatusEffect statusEffect)
        {
            statusEffects.Remove(statusEffect);
            statusEffect.Finish();
        }
    }
}
