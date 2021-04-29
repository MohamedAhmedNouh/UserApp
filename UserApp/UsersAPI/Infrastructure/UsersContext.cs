using System;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;

namespace UsersAPI.Infrastructure
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();
        }
        public DbSet<User> Users { get; set; }
    }
}
