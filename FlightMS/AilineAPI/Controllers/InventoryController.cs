using AilineAPI.Models;
using AilineAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AilineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        FlightDBContext db;
        public InventoryController(FlightDBContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<InventoryTable> ShowData()
        {
            return db.InventoryTables;
        }
        [HttpPost]
        public IActionResult PostData(InventoryViewModel InventoryViewModel)

        {

            InventoryTable inventoryTable = new InventoryTable();
            inventoryTable.FlightNumber = InventoryViewModel.FlightNumber;
            inventoryTable.AirlineId = InventoryViewModel.AirlineId;
            inventoryTable.FromPlace = InventoryViewModel.FromPlace;
            inventoryTable.ToPlace = InventoryViewModel.ToPlace;
            inventoryTable.StartDateTime = InventoryViewModel.StartDateTime;
            inventoryTable.EndDateTime = InventoryViewModel.EndDateTime;
            inventoryTable.ScheduleDays = InventoryViewModel.ScheduleDays;
            inventoryTable.Instrument = InventoryViewModel.Instrument;
            inventoryTable.BusinessClassSeat = InventoryViewModel.BusinessClassSeat;
            inventoryTable.NonBusinessClassSeat = InventoryViewModel.NonBusinessClassSeat;
            inventoryTable.TicketCost = InventoryViewModel.TicketCost;
            inventoryTable.Nrows = InventoryViewModel.Nrows;
            inventoryTable.Meal = InventoryViewModel.Meal;

            db.InventoryTables.Add(inventoryTable);
            db.SaveChanges();
            return Ok("New Record Registered successfully !");
        }

    }
}
