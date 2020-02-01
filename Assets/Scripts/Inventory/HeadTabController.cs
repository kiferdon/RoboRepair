using System;
using Items;
using UnityEngine;

namespace Inventory {
    public class HeadTabController : TabController {
        public override Type Type => typeof(HeadItem);
    }
}