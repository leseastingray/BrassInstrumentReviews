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
        // This DbSet is now taken care of by the parent class, IdentityUser
        //public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Instrument> Instruments { get; set; }

        // Method to seed initial instrument review data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    ReviewID = 1,
                    InstrumentName = "Reynolds Contempora bass trombone",
                    InstrumentType = "Trombone",
                    Rating = 3,
                    ReviewerName = "stingray",
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
             );
        }
    }
}
