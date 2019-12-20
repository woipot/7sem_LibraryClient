using System;
using System.Collections.Generic;

namespace LibraryClient
{
    public partial class OrdersHasBook
    {
        public int OrdersIdOrder { get; set; }
        public int BookIdBook { get; set; }

        public virtual Book BookIdBookNavigation { get; set; }
        public virtual Orders OrdersIdOrderNavigation { get; set; }
    }
}
