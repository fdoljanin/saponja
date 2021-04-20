using Microsoft.EntityFrameworkCore;
using Saponja.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saponja.Data.Entities
{
    public class SaponjaDbContext
    {
        public SaponjaDbContext(DbContextOptions<SaponjaDbContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Adopter> Adopters { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalPhoto> AnimalPhotos { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
