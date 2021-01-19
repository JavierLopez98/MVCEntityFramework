using Microsoft.EntityFrameworkCore;
using NVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVCEntityFramework.Data
{
    public class EnfermosContext:DbContext
    {
        public EnfermosContext(DbContextOptions<EnfermosContext> options) : base(options) { }

        public DbSet<Enfermo> Enfermos { get; set; }
    }
}
