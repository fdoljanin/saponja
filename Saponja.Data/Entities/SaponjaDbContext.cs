using Microsoft.EntityFrameworkCore;
using Saponja.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Saponja.Data.Enums;

namespace Saponja.Data.Entities
{
    public class SaponjaDbContext : DbContext
    {
        public SaponjaDbContext (DbContextOptions<SaponjaDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Adopter> Adopters { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalPhoto> AnimalPhotos { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasDiscriminator(u => u.Role)
                .HasValue<Admin>(UserRole.Admin)
                .HasValue<Shelter>(UserRole.Shelter);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Adopter>()
                .HasOne(ad => ad.Animal)
                .WithMany(an => an.Adopters)
                .HasForeignKey(ad => ad.AnimalId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Shelter)
                .WithMany(s => s.Animals)
                .HasForeignKey(a => a.ShelterId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AnimalPhoto>()
                .HasOne(ap => ap.Animal)
                .WithMany(a => a.AnimalPhotos)
                .HasForeignKey(ap => ap.AnimalId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
