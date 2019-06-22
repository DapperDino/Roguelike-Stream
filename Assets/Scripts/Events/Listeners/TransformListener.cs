using Roguelike.Events.CustomEvents;
using Roguelike.Events.UnityEvents;
using UnityEngine;

namespace Roguelike.Events.Listeners
{
    public class TransformListener : BaseGameEventListener<Transform, TransformEvent, UnityTransformEvent> { }
}
