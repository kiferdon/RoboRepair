using UnityEngine;

namespace Items {
    public struct Stats {
        public int Dexterity { get; }
        public int Strength { get; }
        public int Intelligence { get; }


        public Stats(int dexterity, int strength, int intelligence) {
            Dexterity = dexterity;
            Strength = strength;
            Intelligence = intelligence;
        }
    }
}