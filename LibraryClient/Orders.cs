using System;
using System.Collections.Generic;

namespace LibraryClient
{
    public partial class Orders
    {
        public Orders()
        {
            OrdersHasBook = new HashSet<OrdersHasBook>();
        }

        public int IdOrder { get; set; }
        public DateTime OrderStart { get; set; }
        public DateTime? OrderEnd { get; set; }

        public virtual UserHasOrders UserHasOrders { get; set; }
        public virtual ICollection<OrdersHasBook> OrdersHasBook { get; set; }
    }
}
