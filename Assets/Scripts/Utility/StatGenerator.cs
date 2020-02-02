using System;
using Items;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utility {
    public class StatGenerator : Singleton<StatGenerator> {
        public Sprite[] digits = new Sprite[9];
        public Sprite[] armSprites;
        public Sprite[] legSprites;
        public Sprite[] headSprites;

        public Color strengthColor;
        public Color dexterityColor;
        public Color intelligenceColor;

        public static Stats Stats {
            get
            {
                int randomValue = Random.Range(1, 6);
                int maxStat=4;
                int strength = Random.Range(1, maxStat);
                int dexterity = Random.Range(1, maxStat);
                int intelligence = Random.Range(1, maxStat);
                if (randomValue == 1)
                {
                    strength = Random.Range(4, 7);
                }
                else if (randomValue == 2)
                {
                    intelligence = Random.Range(4, 7);

                }
                else if(randomValue == 3)
                {
                    dexterity = Random.Range(4, 7);

                }
                return new Stats(dexterity, strength, intelligence);
            }
        }

        public static Sprite DigitToSprite(int digit) {
            return Instance.digits[digit - 1];
        }

        public static Color GetColor(Stats stats) {
            var dexterity = stats.Dexterity;
            var strength = stats.Strength;
            var intelligence = stats.Intelligence;
            if (strength >= dexterity && strength >= intelligence) {
                return Instance.strengthColor;
            }
            else if (dexterity >= strength && dexterity >= intelligence) {
                return Instance.dexterityColor;
            }
            else if (intelligence >= dexterity && intelligence >= strength) {
                return Instance.intelligenceColor;
            }

            throw new ArgumentException("Cannot get proper background");
        }

        public static Sprite GetSprite(Parts part) {
            switch (part) {
                case Parts.ARM:
                    return Instance.armSprites[Random.Range(0, Instance.armSprites.Length)];
                case Parts.LEG:
                    return Instance.legSprites[Random.Range(0, Instance.legSprites.Length)];
                case Parts.HEAD:
                    return Instance.headSprites[Random.Range(0, Instance.headSprites.Length)];
            }

            throw new ArgumentException("Cant find part");
        }
    }
}