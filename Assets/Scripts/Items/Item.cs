using System;
using UnityEngine;
using Utility;

namespace Items {
    public class Item : PoolObject, IComparable<Item> {
        public SpriteRenderer frontRenderer;
        public SpriteRenderer backRenderer;
        public SpriteRenderer realSprite;
        public SpriteRenderer shadowSprite;
        [SerializeField] protected SpriteRenderer strengthRenderer;
        [SerializeField] protected SpriteRenderer dexterityRenderer;
        [SerializeField] protected SpriteRenderer intelligenceRenderer;
        public Stats stats;

        public override void Init() {
            stats = StatGenerator.Stats;
            strengthRenderer.sprite = StatGenerator.DigitToSprite(stats.Strength);
            dexterityRenderer.sprite = StatGenerator.DigitToSprite(stats.Dexterity);
            intelligenceRenderer.sprite = StatGenerator.DigitToSprite(stats.Intelligence);
            DisableRealSprite();
        }

        public int CompareTo(Item other) {
            var max = stats.Intelligence;
            var sum = stats.Intelligence + stats.Strength + stats.Dexterity;
            var otherSum = other.stats.Intelligence + other.stats.Strength + other.stats.Dexterity;
            if (sum > otherSum) {
                return -1;
            }
            else if (sum < otherSum) {
                return 1;
            }

            if (stats.Strength > max) {
                max = stats.Strength;
            }

            if (stats.Dexterity > max) {
                max = stats.Dexterity;
            }

            if (max > other.stats.Intelligence && max > other.stats.Strength && max > other.stats.Dexterity) {
                return -1;
            }

            return 1;
        }

        public void EnableRealSprite(float yRotation, Vector3 connectPosition) {
            realSprite.gameObject.SetActive(true);
            realSprite.transform.Rotate(Vector3.up * (yRotation), Space.Self);
            realSprite.transform.position = connectPosition;
            frontRenderer.gameObject.SetActive(false);
            backRenderer.gameObject.SetActive(false);
        }

        public void DisableRealSprite() {
            realSprite.gameObject.SetActive(false);
            realSprite.transform.localRotation = Quaternion.Euler(Vector3.zero);
            frontRenderer.gameObject.SetActive(true);
            backRenderer.gameObject.SetActive(true);
        }

        public void EnableShadowSprite(float yRotation, Vector3 connectPosition) {
            shadowSprite.gameObject.SetActive(true);
            shadowSprite.transform.Rotate(Vector3.up * (yRotation), Space.Self);
            shadowSprite.transform.position = connectPosition;
            //frontRenderer.gameObject.SetActive(false);
            //backRenderer.gameObject.SetActive(false);
        }

        public void DisableShadowSprite() {
            shadowSprite.gameObject.SetActive(false);
            shadowSprite.transform.localRotation = Quaternion.Euler(Vector3.zero);
            frontRenderer.gameObject.SetActive(true);
            backRenderer.gameObject.SetActive(true);
        }
    }
}