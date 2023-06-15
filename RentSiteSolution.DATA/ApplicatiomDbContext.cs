using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RentSiteSolution.DATA.Entity.Apartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSiteSolution.DATA
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }*/
        public DbSet<Apartment> Apartments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Определение столбца Photos в таблице Apartments
            modelBuilder.Entity<Apartment>()
                .Property(a => a.Photos)
                .HasConversion(
                    v => string.Join(";", v),  // Преобразование массива в строку с разделителем ";"
                    v => v.Split(";", StringSplitOptions.None)); // Преобразование строки в массив с разделителем ";"
        }

    }
}
