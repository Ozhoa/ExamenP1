using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamenP1.Models
{
    public class DigimondContext : DbContext
    {
        public DigimondContext () : base("name=DigimondContext") {}
        public DbSet<Digimon> Digimones { get; set; }
        public DbSet<Ataque> Ataques { get; set; }

    }
}