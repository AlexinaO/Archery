using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Archery.Data;

namespace Archery.Migrations
{
    public class Configuration : DbMigrationsConfiguration<ArcheryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}