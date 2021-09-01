using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BakeryShop.DataAccess.Entities
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }

        [NotMapped]
        public string[] Roles { get; set; }
    }
}
