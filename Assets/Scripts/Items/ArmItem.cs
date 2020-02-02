using Utility;

namespace Items {
    public class ArmItem : Item {
        public override void Init() {
            base.Init();
            frontRenderer.sprite = StatGenerator.GetSprite(Parts.ARM);
            frontRenderer.color = StatGenerator.GetColor(stats);
            int number;
            shadowSprite.sprite = ItemImageSource.GetShadowArm(out number);
            realSprite.sprite = ItemImageSource.GetArm(number);

        }
    }
}