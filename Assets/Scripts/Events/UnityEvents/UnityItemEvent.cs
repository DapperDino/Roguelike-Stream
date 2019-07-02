using Roguelike.Items;
using System;
using UnityEngine.Events;

namespace Roguelike.Events.UnityEvents
{
    [Serializable] public class UnityItemEvent : UnityEvent<Item> { }
}