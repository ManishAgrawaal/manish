using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;

namespace TicketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        FlightDBContext db;
        public TicketController(FlightDBContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IActionResult GetByPnr(string Pnr)
        {
            var data = db.BookingTables.SingleOrDefault(x => x.Pnr == Pnr);
            if (data == null)
            {
                return Ok("Record not found !");
            }
            return Ok(data);

        }
    }
}
