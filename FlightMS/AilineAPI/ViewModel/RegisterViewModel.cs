using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AilineAPI.ViewModel
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        public string AirlineName { get; set; }
        public string Logo { get; set; }
        public long? Cnumber { get; set; }
        public string Caddress { get; set; }
    }
}
