using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FSP_Return_Task3.Models;

namespace FSP_Return_Task3.Data
{
    public class FSP_Return_Task3Context : DbContext
    {
        public FSP_Return_Task3Context (DbContextOptions<FSP_Return_Task3Context> options)
            : base(options)
        {
        }

        public DbSet<FSP_Return_Task3.Models.Passenger> Passenger { get; set; } = default!;

        public DbSet<FSP_Return_Task3.Models.Passport>? Passport { get; set; }
    }
}
