using System;
using System.Collections.Generic;

namespace LibraryClient
{
    public partial class BookHasAuthor
    {
        public int BookIdBook { get; set; }
        public int AuthorIdAuthor { get; set; }

        public virtual Author AuthorIdAuthorNavigation { get; set; }
        public virtual Book BookIdBookNavigation { get; set; }
    }
}
