using BookingAPI.Models;
using BookingAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        FlightDBContext db;
        public BookingController(FlightDBContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<BookingTable> ShowData()
        {
            return db.BookingTables;
        }
        [HttpPost]
        public IActionResult PostData(BookingViewModel bookingViewModel)

        {
            Random random = new Random();
            int pnr = random.Next();
            BookingTable bookingTable = new BookingTable();
            bookingTable.UserId = bookingViewModel.UserId;
            bookingTable.Email = bookingViewModel.Email;
            bookingTable.NumberOfSeat = bookingViewModel.NumberOfSeat;
            bookingTable.PassengerName = bookingViewModel.PassengerName;
            bookingTable.Gender = bookingViewModel.Gender;
            bookingTable.Age = bookingViewModel.Age;
            bookingTable.OptionforMeal = bookingViewModel.OptionforMeal;
            bookingTable.SeatNumber = bookingViewModel.SeatNumber;
            bookingTable.Pnr = pnr.ToString();
            db.BookingTables.Add(bookingTable);
            db.SaveChanges();
            return Ok("Your Ticket has been booked succefully ! Your PNR Number is : " + pnr);

        }
        [HttpGet("{Email}", Name = "GetDetailsByEmail")]
        public IActionResult GetByEmail(string Email)
        {
            var data = db.BookingTables.SingleOrDefault(x => x.Email == Email);
            if (data == null)
            {
                return Ok("Record not found !");
            }
            return Ok(data);

        }
        [HttpDelete]
        public IActionResult cancelByPnr(PnrViewModel pnrViewModel)

        {
            if (db.BookingTables.Any(x => x.Pnr == pnrViewModel.Pnr))
            {
                var data = db.BookingTables.Where(x => x.Pnr == pnrViewModel.Pnr).FirstOrDefault();
                db.BookingTables.Remove(data);
                db.SaveChanges();
                return Ok("Your booking has been canceled Successfully.");
            }

            return BadRequest("Record not found.");
        }


    }
}
