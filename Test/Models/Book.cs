using System;
using System.Collections.Generic;

#nullable disable

namespace Test.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? EditorialId { get; set; }
        public bool? Status { get; set; }

        public virtual Editorial Editorial { get; set; }
    }
}
