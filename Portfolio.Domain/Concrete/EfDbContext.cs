using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Abstract;

namespace Portfolio.Domain.Concrete
{
    public class EfDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
