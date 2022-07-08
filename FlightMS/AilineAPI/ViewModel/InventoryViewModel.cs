using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AilineAPI.ViewModel
{
    public class InventoryViewModel
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public int? AirlineId { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string ScheduleDays { get; set; }
        public string Instrument { get; set; }
        public int? BusinessClassSeat { get; set; }
        public int? NonBusinessClassSeat { get; set; }
        public string TicketCost { get; set; }
        public int? Nrows { get; set; }
        public string Meal { get; set; }
    }
}
