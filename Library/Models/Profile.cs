using System;
using System.Collections.Generic;

namespace Library.Models
{
    public partial class Profile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
