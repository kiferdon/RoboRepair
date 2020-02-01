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

        public void ActivateRealForm()
        {
            
        }
    }
}