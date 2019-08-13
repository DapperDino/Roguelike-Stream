using UnityEngine;

namespace Roguelike.Events.CustomEvents
{
    [CreateAssetMenu(fileName = "New Audio Clip Event", menuName = "Game Events/Audio Clip Event")]
    public class AudioClipEvent : BaseGameEvent<AudioClip> { }
}
