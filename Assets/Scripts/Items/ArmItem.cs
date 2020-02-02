using Utility;

namespace Items {
    public class ArmItem : Item {
        public override void Init() {
            base.Init();
            frontRenderer.sprite = StatGenerator.GetSprite(Parts.ARM);
            frontRenderer.color = StatGenerator.GetColor(stats);
            realSprite.sprite = ItemImageSource.GetArm();
            shadowSprite.sprite = ItemImageSource.GetShadowArm();

        }
    }
}