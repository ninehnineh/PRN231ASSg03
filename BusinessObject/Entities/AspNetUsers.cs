using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entities
{
    public class AspNetUsers : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Order> Orders { get; set; }

    }
}
