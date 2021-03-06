﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DiplomskiCore1.Models;
using DiplomskiCore1.Models.New_Models;
using DiplomskiCore1.Models.NewModels;

namespace DiplomskiCore1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Blog> Blog { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<BlogActivity> BlogActivity { get; set; }

        // add new models
        public DbSet<Post> Post { get; set; }
        public DbSet<NewComment> NewComment { get; set; }
        public DbSet<Action> Action { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<BlogActivity>()
            .HasKey(c => new { c.AuthorId, c.BlogId });

            // add complex foreighn key for action
            builder.Entity<Action>()
                .HasKey(c => new { c.HistoryId, c.EntityId, c.AuthorId });
        }
    }
}
