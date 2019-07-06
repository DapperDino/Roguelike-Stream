using Roguelike.Combat;
using UnityEngine;

namespace Roguelike.Events.CustomEvents
{
    [CreateAssetMenu(fileName = "New Damageable Event", menuName = "Game Events/Damageable Event")]
    public class DamageableEvent : BaseGameEvent<Damageable> { }
}
