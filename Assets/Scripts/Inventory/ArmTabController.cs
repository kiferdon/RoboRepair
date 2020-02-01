using System;
using Items;

namespace Inventory {
    public class ArmTabController : TabController {
        public override Type Type => typeof(ArmItem);
    }
}