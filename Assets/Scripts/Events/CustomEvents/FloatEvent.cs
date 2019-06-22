using UnityEngine;

namespace Roguelike.Events.CustomEvents
{
    [CreateAssetMenu(fileName = "New Float Event", menuName = "Game Events/Float Event")]
    public class FloatEvent : BaseGameEvent<float> { }
}
