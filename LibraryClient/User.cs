using System;
using System.Collections.Generic;

namespace LibraryClient
{
    public partial class User
    {
        public User()
        {
            UserHasOrders = new HashSet<UserHasOrders>();

            Name = " ";
            Phone = " ";
            Adres = " ";
        }

        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Adres { get; set; }

        public virtual ICollection<UserHasOrders> UserHasOrders { get; set; }
    }
}
