using UnityEngine;
using Utility;

namespace Items {
    public class Item : PoolObject {
        public SpriteRenderer frontRenderer;
        public SpriteRenderer backRenderer;
        public SpriteRenderer realSprite;
        [SerializeField] protected SpriteRenderer strengthRenderer;
        [SerializeField] protected SpriteRenderer dexterityRenderer;
        [SerializeField] protected SpriteRenderer intelligenceRenderer;
        public Stats stats;

        public override void Init() {
            stats = StatGenerator.Stats;
            strengthRenderer.sprite = StatGenerator.DigitToSprite(stats.Strength);
            dexterityRenderer.sprite = StatGenerator.DigitToSprite(stats.Dexterity);
            intelligenceRenderer.sprite = StatGenerator.DigitToSprite(stats.Intelligence);
        }

        public void EnableRealSprite(float yRotation)
        {
            realSprite.gameObject.SetActive(true);
            realSprite.transform.Rotate(Vector3.up*yRotation,Space.Self);
            frontRenderer.gameObject.SetActive(false);
        }

        public void DisableRealSprite()
        {
            realSprite.gameObject.SetActive(false);
            realSprite.transform.localRotation = Quaternion.Euler(Vector3.zero);
            frontRenderer.gameObject.SetActive(true);

        }
    }
}