using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrassInstrumentReviews.Models
{
    // Inherits from IdentityDbContext to enable Identity
    public class InstrumentReviewContext : IdentityDbContext<Reviewer>
    {
        public InstrumentReviewContext(DbContextOptions<InstrumentReviewContext> options) : base(options) { }

        // DbSet for the database
        public DbSet<Review> Reviews { get; set; }
        // This DbSet is now taken care of by the parent class, IdentityUser?
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        // New, now with comments! for extended domain model
        public DbSet<Comment> Comments { get; set; }

        // Method to seed initial instrument review data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    ReviewID = 1,
                    InstrumentName = "Reynolds Contempora bass trombone",
                    InstrumentType = "Trombone",
                    Rating = 3,
                    Reviewer = "stingray",
                    ReviewDate = new DateTime(2020, 3, 4)
                },
                new Review
                {
                    ReviewID = 2,
                    InstrumentName = "Bach Stradivarius Bb trumpet",
                    InstrumentType = "Trumpet",
                    Rating = 4,
                    ReviewerName = "Spot",
                    ReviewDate = new DateTime(2020, 7, 4)
                },
                new Review
                {
                    ReviewID = 3,
                    InstrumentName = "Conn 8D horn",
                    InstrumentType = "French horn",
                    Rating = 5,
                    ReviewerName = "Megan cat",
                    ReviewDate = new DateTime(2020, 12, 1)
                }
             );*/
        }
        // Method to seed Roles and Reviewer Users, this method is called in Startup.cs
        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            // Instantiate UserManager and RoleManager objects using IServiceProvider
            UserManager<Reviewer> userManager = serviceProvider.GetRequiredService<UserManager<Reviewer>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Instantiate string variables
            string username = "admin";
            string password = "africanPenguin$1";
            string roleName = "Admin";

            // if role does not exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // if username does not exit, create it and add to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                Reviewer reviewer = new Reviewer { UserName = username };
                var result = await userManager.CreateAsync(reviewer, password);

                // check for success and add the reviewer to the role
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(reviewer, roleName);
                }
            }

        }
    }
}
