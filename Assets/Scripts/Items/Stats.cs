using UnityEngine;

namespace Items {
    public struct Stats {
        public int Dexterity { get; }
        public int Strength { get; }
        public int Intelligence { get; }
        public Sprite Background { get; }

        public Stats(int dexterity, int strength, int intelligence, Sprite background) {
            Dexterity = dexterity;
            Strength = strength;
            Intelligence = intelligence;
            Background = background;
        }
    }
}