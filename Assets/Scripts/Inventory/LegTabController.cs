using System;
using Items;

namespace Inventory {
    public class LegTabController : TabController {
        public override Type Type => typeof(LegItem);
    }
}