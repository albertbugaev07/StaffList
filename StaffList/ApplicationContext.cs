using Microsoft.EntityFrameworkCore;
using StaffList.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffList
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PositionProcessing> PositionProcessings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=stafflist1;Trusted_Connection=True;");
        }
    }
}
