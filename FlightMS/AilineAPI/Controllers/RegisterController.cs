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
    public class RegisterController : ControllerBase
    {
        FlightDBContext db;
        public RegisterController(FlightDBContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<RegisterTable>ShowData()
        {
            return db.RegisterTables;
        }
        [HttpPost]
        public IActionResult PostData(RegisterViewModel registerViewModel)

        {
          RegisterTable registerTable = new RegisterTable();
            registerTable.AirlineName = registerViewModel.AirlineName;
            registerTable.Logo = registerViewModel.Logo;
            registerTable.Cnumber = registerViewModel.Cnumber;
            registerTable.Caddress = registerViewModel.Caddress;
            db.RegisterTables.Add(registerTable);
            db.SaveChanges();
            return Ok("New Record Registered successfully !");
        }
        [HttpPut]
        public IActionResult PutData(RegisterViewModel registerViewModel)
        {
            if (db.RegisterTables.Any(x => x.Id == registerViewModel.Id))
            {
                var data = db.RegisterTables.Where(x => x.Id == registerViewModel.Id).FirstOrDefault();
                data.AirlineName = registerViewModel.AirlineName;
                data.Logo = registerViewModel.Logo;
                data.Cnumber = registerViewModel.Cnumber;
                data.Caddress = registerViewModel.Caddress;
                db.RegisterTables.Update(data);
                db.SaveChanges();
                return Ok("Record have been successfully updated.");

            }
            return BadRequest("Record not found");
        }
        [HttpDelete]
        public IActionResult deleteData(RegisterViewModel registerViewModel)

        {
            if (db.RegisterTables.Any(x => x.Id == registerViewModel.Id))
            {
                var data = db.RegisterTables.Where(x => x.Id == registerViewModel.Id).FirstOrDefault();
                db.RegisterTables.Remove(data);
                db.SaveChanges();
                return Ok("Record deleted Successfully.");
            }

            return BadRequest("Record not found.");
        }
    }
}
