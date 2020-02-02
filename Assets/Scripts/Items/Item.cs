using UnityEngine;
using Utility;

namespace Items {
    public class Item : PoolObject {
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

        public void EnableRealSprite(float yRotation,Vector3 connectPosition)
        {
            realSprite.gameObject.SetActive(true);
            realSprite.transform.Rotate(Vector3.up*(yRotation),Space.Self);
            realSprite.transform.position = connectPosition;
            frontRenderer.gameObject.SetActive(false);
            backRenderer.gameObject.SetActive(false);
        }

        public void DisableRealSprite()
        {
            realSprite.gameObject.SetActive(false);
            realSprite.transform.localRotation = Quaternion.Euler(Vector3.zero);
            frontRenderer.gameObject.SetActive(true);
            backRenderer.gameObject.SetActive(true);

        }
        
        public void EnableShadowSprite(float yRotation,Vector3 connectPosition)
        {
            shadowSprite.gameObject.SetActive(true);
            shadowSprite.transform.Rotate(Vector3.up*(yRotation),Space.Self);
            shadowSprite.transform.position = connectPosition;
            //frontRenderer.gameObject.SetActive(false);
            //backRenderer.gameObject.SetActive(false);
        }
        
        public void DisableShadowSprite()
        {
            shadowSprite.gameObject.SetActive(false);
            shadowSprite.transform.localRotation = Quaternion.Euler(Vector3.zero);
            frontRenderer.gameObject.SetActive(true);
            backRenderer.gameObject.SetActive(true);

        }
    }
}