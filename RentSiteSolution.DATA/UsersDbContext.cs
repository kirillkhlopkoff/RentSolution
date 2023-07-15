using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RentSiteSolution.DATA.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSiteSolution.DATA
{
    /*public class UsersDbContext : IdentityDbContext<User, Role, string>
    {
        private readonly IConfiguration _configuration;
        public UsersDbContext(DbContextOptions<UsersDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        *//*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"));
        }*//*
    }*/
}
