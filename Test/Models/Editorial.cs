using System;
using System.Collections.Generic;

#nullable disable

namespace Test.Models
{
    public partial class Editorial
    {
        public Editorial()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
