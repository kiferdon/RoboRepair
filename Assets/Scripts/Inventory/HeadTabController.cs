using System;
using Items;

namespace Inventory {
    public class HeadTabController : TabController {
        public override Type Type => typeof(HeadItem);
    }
}