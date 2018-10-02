﻿using Archery.Models;
using System.Data.Entity;

namespace Archery.Data
{
    public class ArcheryDbContext : DbContext
    {
        public ArcheryDbContext() : base("Archery")
        {
        }

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Archer> Archers { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<Bow> Bows { get; set; }

        public DbSet<Shooter> Shooters { get; set; }

    }
}