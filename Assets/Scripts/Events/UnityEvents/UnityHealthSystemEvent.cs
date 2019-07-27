using Roguelike.Combat;
using System;
using UnityEngine.Events;

namespace Roguelike.Events.UnityEvents
{
    [Serializable] public class UnityHealthSystemEvent : UnityEvent<HealthSystem> { }
}