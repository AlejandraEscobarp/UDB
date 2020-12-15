using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UDB.Models;

namespace UDB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Carreras> carreras { get; set; }

        public DbSet<Contactanos> contactanos { get; set; }

        public DbSet<Noticias> noticias { get; set; }
    }
}
