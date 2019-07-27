using Roguelike.Combat;
using UnityEngine;

namespace Roguelike.Events.CustomEvents
{
    [CreateAssetMenu(fileName = "New Health System Event", menuName = "Game Events/Health System Event")]
    public class HealthSystemEvent : BaseGameEvent<HealthSystem> { }
}
