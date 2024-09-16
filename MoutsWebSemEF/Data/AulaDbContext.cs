using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoutsWebSemEF.Models;

namespace MoutsWebSemEF.Data
{
    public class AulaDbContext : DbContext
    {
        public AulaDbContext (DbContextOptions<AulaDbContext> options)
            : base(options)
        {
        }

        public DbSet<MoutsWebSemEF.Models.Produto> Produto { get; set; } = default!;
        public DbSet<MoutsWebSemEF.Models.Cliente> Cliente { get; set; } = default!;
    }
}
