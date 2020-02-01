using System;
using Items;
using UnityEngine.Events;

namespace Events {
    [Serializable]
    public class UnityItemEvent : UnityEvent<Item> {
    }
}