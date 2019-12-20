using System;
using System.Collections.Generic;

namespace LibraryClient
{
    public partial class UserHasOrders
    {
        public int OrdersIdOrder { get; set; }
        public int UserIdUser { get; set; }

        public virtual Orders OrdersIdOrderNavigation { get; set; }
        public virtual User UserIdUserNavigation { get; set; }
    }
}
