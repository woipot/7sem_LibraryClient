using System;
using System.Collections.Generic;

namespace LibraryClient
{
    public partial class Book
    {
        public Book()
        {
            BookHasAuthor = new HashSet<BookHasAuthor>();
            OrdersHasBook = new HashSet<OrdersHasBook>();
        }

        public int IdBook { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int? Price { get; set; }

        public virtual ICollection<BookHasAuthor> BookHasAuthor { get; set; }
        public virtual ICollection<OrdersHasBook> OrdersHasBook { get; set; }
    }
}
