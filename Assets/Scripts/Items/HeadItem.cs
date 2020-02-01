using Utility;

namespace Items {
    public class HeadItem : Item {
        public override void Init() {
            base.Init();
            frontRenderer.sprite = StatGenerator.GetSprite(Parts.HEAD);
            frontRenderer.color = StatGenerator.GetColor(stats);
            realSprite.sprite = ItemImageSource.GetHead();
        }
    }
}