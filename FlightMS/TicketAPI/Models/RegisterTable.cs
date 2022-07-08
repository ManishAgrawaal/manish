using System;
using System.Collections.Generic;

#nullable disable

namespace TicketAPI.Models
{
    public partial class RegisterTable
    {
        public int Id { get; set; }
        public string AirlineName { get; set; }
        public string Logo { get; set; }
        public long? Cnumber { get; set; }
        public string Caddress { get; set; }
    }
}
