using System;
using System.Collections.Generic;

#nullable disable

namespace UserAPI.Models
{
    public partial class BookingTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? NumberOfSeat { get; set; }
        public string PassengerName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string OptionforMeal { get; set; }
        public string SeatNumber { get; set; }
        public string Pnr { get; set; }
    }
}
