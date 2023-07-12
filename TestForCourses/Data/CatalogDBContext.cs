using Microsoft.EntityFrameworkCore;
using System.Xml;
using TestForCourses.Data.Models;
using Path = TestForCourses.Data.Models.Path;

namespace TestForCourses.Data
{
    public class CatalogDBContext : DbContext
    {
       
        public CatalogDBContext(DbContextOptions<CatalogDBContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<Path> Paths { get; set; }

        
    }
}
