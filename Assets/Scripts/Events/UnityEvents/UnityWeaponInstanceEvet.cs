﻿using Roguelike.Weapons;
using System;
using UnityEngine.Events;

namespace Roguelike.Events.UnityEvents
{
    [Serializable] public class UnityWeaponInstanceEvent : UnityEvent<WeaponInstance> { }
}