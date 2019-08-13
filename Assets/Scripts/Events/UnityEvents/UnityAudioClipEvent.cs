using System;
using UnityEngine;
using UnityEngine.Events;

namespace Roguelike.Events.UnityEvents
{
    [Serializable] public class UnityAudioClipEvent : UnityEvent<AudioClip> { }
}