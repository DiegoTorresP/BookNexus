using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookNexus.Models;

namespace BookNexus.Data
{
    public class BookNexusContext : DbContext
    {
        public BookNexusContext (DbContextOptions<BookNexusContext> options)
            : base(options)
        {
        }

        public DbSet<BookNexus.Models.Book> Book { get; set; } = default!;

        public DbSet<BookNexus.Models.Usuarios> Usuarios { get; set; }
    }
}
