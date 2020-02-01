using System;
using UnityEngine;

namespace ScriptableObjects.Variables {
    [CreateAssetMenu(menuName = "Variables/Int")]
    public class IntVariable : ScriptableObject {
        public int value;
    }
}