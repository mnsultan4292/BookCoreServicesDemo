using System;
using System.Collections.Generic;

namespace BookCoreServicesDemo.Models
{
    public partial class UserLogin
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
