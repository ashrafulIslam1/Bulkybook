using Bulkybook.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulkybook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Here I created a table name Categories in Database which will have all the data from Category Model.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<BaseEntity> BaseEntity { get; set; }

    }
}
