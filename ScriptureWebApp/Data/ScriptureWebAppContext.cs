using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScriptureWebApp.Models;

namespace ScriptureWebApp.Data
{
    public class ScriptureWebAppContext : DbContext
    {
        public ScriptureWebAppContext (DbContextOptions<ScriptureWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<ScriptureWebApp.Models.Scripture> Scripture { get; set; }
    }
}
