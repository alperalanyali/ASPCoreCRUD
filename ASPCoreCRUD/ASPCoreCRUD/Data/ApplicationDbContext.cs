using System;
using ASPCoreCRUD.Models;
using Microsoft.EntityFrameworkCore;
namespace ASPCoreCRUD.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Etiket> Etiket { get; set; }
    }
}
