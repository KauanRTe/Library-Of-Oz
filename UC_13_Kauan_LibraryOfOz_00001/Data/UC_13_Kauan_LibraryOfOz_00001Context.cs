using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UC_13_Kauan_LibraryOfOz_00001.Models;

namespace UC_13_Kauan_LibraryOfOz_00001.Data
{
    public class UC_13_Kauan_LibraryOfOz_00001Context : DbContext
    {
        public UC_13_Kauan_LibraryOfOz_00001Context (DbContextOptions<UC_13_Kauan_LibraryOfOz_00001Context> options)
            : base(options)
        {
        }

        public DbSet<UC_13_Kauan_LibraryOfOz_00001.Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<UC_13_Kauan_LibraryOfOz_00001.Models.Estoque>? Estoque { get; set; }

        public DbSet<UC_13_Kauan_LibraryOfOz_00001.Models.Aluguel>? Aluguel { get; set; }
    }
}
