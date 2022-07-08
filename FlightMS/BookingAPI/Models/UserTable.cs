using System;
using System.Collections.Generic;

#nullable disable

namespace BookingAPI.Models
{
    public partial class UserTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Paaword { get; set; }
    }
}
