using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Filip_ASP_NET_Core_1.Classes;

namespace Filip_ASP_NET_Core_1.Data
{
    public class Filip_ASP_NET_Core_1Context : DbContext
    {
        public Filip_ASP_NET_Core_1Context (DbContextOptions<Filip_ASP_NET_Core_1Context> options)
            : base(options)
        {
        }

        public DbSet<Filip_ASP_NET_Core_1.Classes.Database_Object> Database_Object { get; set; }
    }
}
