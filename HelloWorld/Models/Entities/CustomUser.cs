using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Models.Entities
{
    public class CustomUser : IdentityUser //to jest chyba jakby encja "CustomUser"
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AboutMe { get; set; }

    }
}
