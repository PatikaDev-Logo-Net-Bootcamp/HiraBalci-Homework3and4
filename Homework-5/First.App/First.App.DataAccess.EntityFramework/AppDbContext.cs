﻿using First.App.DataAccess.EntityFramework.Configurations;
using First.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace First.App.DataAccess.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());//buda tablo oluşturur.has key falan da yazabilirsin ama tablomun
            //configuration class olucak dedim.
            modelBuilder.ApplyConfiguration(new PostConfiguration());
        }

    }
}
