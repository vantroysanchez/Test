using System.Collections.Generic;

namespace Test.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public int? BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
