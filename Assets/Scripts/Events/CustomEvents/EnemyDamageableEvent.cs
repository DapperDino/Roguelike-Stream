using Roguelike.Combat;
using UnityEngine;

namespace Roguelike.Events.CustomEvents
{
    [CreateAssetMenu(fileName = "New Enemy Damageable Event", menuName = "Game Events/Enemy Damageable Event")]
    public class EnemyDamageableEvent : BaseGameEvent<EnemyHealthSystem> { }
}
