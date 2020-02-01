using UnityEngine;
using Utility;

namespace Items {
    public class Item : PoolObject {
        public SpriteRenderer backRenderer;
        [SerializeField] protected SpriteRenderer strengthRenderer;
        [SerializeField] protected SpriteRenderer dexterityRenderer;
        [SerializeField] protected SpriteRenderer intelligenceRenderer;
        public Stats stats;

        public override void Init() {
            stats = StatGenerator.Stats;
            backRenderer.sprite = stats.Background;
            strengthRenderer.sprite = StatGenerator.DigitToSprite(stats.Strength);
            dexterityRenderer.sprite = StatGenerator.DigitToSprite(stats.Dexterity);
            intelligenceRenderer.sprite = StatGenerator.DigitToSprite(stats.Intelligence);
        }
    }
}