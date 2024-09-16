using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoutsWeb.Models;

namespace MoutsWeb.Data
{
    public class AulaDb : DbContext
    {
        public AulaDb (DbContextOptions<AulaDb> options)
            : base(options)
        {
        }

        public DbSet<MoutsWeb.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<MoutsWeb.Models.Produto> Produto { get; set; } = default!;
        public DbSet<MoutsWeb.Models.Venda> Venda { get; set; } = default!;
    }
}
