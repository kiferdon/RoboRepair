using System;
using Items;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utility {
    public class StatGenerator : Singleton<StatGenerator> {
        public Sprite[] digits = new Sprite[9];
        public Sprite strengthBack;
        public Sprite dexterityBack;
        public Sprite intelligenceBack;

        public static Stats Stats {
            get {
                var strength = Random.Range(1, 9);
                var dexterity = Random.Range(1, 9);
                var intelligence = Random.Range(1, 9);
                return new Stats(dexterity, strength, intelligence, GetBackground(dexterity, strength, intelligence));
            }
        }

        public static Sprite DigitToSprite(int digit) {
            return Instance.digits[digit - 1];
        }

        private static Sprite GetBackground(int dexterity, int strength, int intelligence) {
            if (strength >= dexterity && strength >= intelligence) {
                return Instance.strengthBack;
            }
            else if (dexterity >= strength && dexterity >= intelligence) {
                return Instance.dexterityBack;
            }
            else if (intelligence >= dexterity && intelligence >= strength) {
                return Instance.intelligenceBack;
            }

            throw new ArgumentException("Cannot get proper background");
        }
    }
}