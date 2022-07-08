using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.ViewModel
{
    public class BookingViewModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public int? NumberOfSeat { get; set; }
        public string PassengerName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string OptionforMeal { get; set; }
        public string SeatNumber { get; set; }
        
    }
}
