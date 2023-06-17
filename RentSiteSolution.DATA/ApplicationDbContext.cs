﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Photo> Photos { get; set; }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Apartment>()
                .HasOne(a => a.MainPhoto)
                .WithMany()
                .HasForeignKey(a => a.MainPhotoId);
        }*/

    }
}
