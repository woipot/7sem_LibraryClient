using System;
using System.Collections.Generic;

namespace LibraryClient
{
    public partial class Author
    {
        public Author()
        {
            BookHasAuthor = new HashSet<BookHasAuthor>();
        }

        public int IdAuthor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual ICollection<BookHasAuthor> BookHasAuthor { get; set; }
    }
}
