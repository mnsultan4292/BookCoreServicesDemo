using System;
using System.Collections.Generic;

namespace BookCoreServicesDemo.Models
{
    public partial class UserRegistration
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
