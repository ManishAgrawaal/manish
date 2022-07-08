using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;
using UserAPI.ViewModel;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        FlightDBContext db;
        public UserController(FlightDBContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<UserTable> ShowData()
        {
            return db.UserTables;
        }
        [HttpPost]
        public IActionResult PostData(UserViewModel userViewModel)

        {
            UserTable userTable = new UserTable();
            userTable.Name = userViewModel.Name;
            userTable.Email = userViewModel.Email;
            userTable.Paaword = userViewModel.Paaword;
            db.UserTables.Add(userTable);
            db.SaveChanges();
            return Ok("New Record Registered successfully !");
        }
        [HttpPut]
        public IActionResult PutData(IDViewModel iDViewModel)
        {
            if (db.UserTables.Any(x => x.Id == iDViewModel.Id))
            {
                var data = db.UserTables.Where(x => x.Id == iDViewModel.Id).FirstOrDefault();
                data.Id = iDViewModel.Id;
                data.Name = iDViewModel.Name;
                data.Email = iDViewModel.Email;
                data.Paaword = iDViewModel.Paaword;
                db.UserTables.Update(data);
                db.SaveChanges();
                return Ok("Record have been successfully updated.");

            }
            return Ok("Record not found");
        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteById(int Id)

        {
            if (db.UserTables.Any(x => x.Id == Id))
            {
                var data = db.UserTables.Where(x => x.Id == Id).FirstOrDefault();
                db.UserTables.Remove(data);
                db.SaveChanges();
                return Ok("deleted Successfully.");
            }

            return BadRequest("Record not found.");


        }
    }
}
    
