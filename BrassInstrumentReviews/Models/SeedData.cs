using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BrassInstrumentReviews.Models
{
    public class SeedData
    {
        public static void Seed(InstrumentReviewContext context, UserManager<Reviewer> userManager,
                                   RoleManager<IdentityRole> roleManager)
        {
            if (!context.Reviews.Any())
            {
                // TODO: check the results and do something if the operation failed--if it ever does
                var result = roleManager.CreateAsync(new IdentityRole("Member")).Result;
                result = roleManager.CreateAsync(new IdentityRole("Admin")).Result;

                // Seeds a default administrator
                Reviewer siteAdmin = new Reviewer
                {
                    UserName = "ReviewAdmin",
                    Name = "Admin Person"
                };
                userManager.CreateAsync(siteAdmin, "africanPenguin1$").Wait();
                IdentityRole adminRole = roleManager.FindByNameAsync("Admin").Result;
                userManager.AddToRoleAsync(siteAdmin, adminRole.Name);

                // Seed users and reviews for manual site testing

                Reviewer stingray = new Reviewer
                {
                    UserName = "stingray",
                    Name = "Amy Lee"
                };
                context.Users.Add(stingray);
                context.SaveChanges();   // This will add a UserID to the Reviewer object

                Review review = new Review
                {
                    InstrumentName = "Reynolds Contempora bass trombone",
                    InstrumentType = "Trombone",
                    Rating = 3,
                    ReviewText = "Good value, plays pretty well for a single-valve bass trombone.",
                    Reviewer = stingray,
                    ReviewDate = new DateTime(2020, 3, 4)
                };
                context.Reviews.Add(review);  // queues up the review to be added to the DB

                Reviewer spot = new Reviewer
                {
                    UserName = "Spot",
                    Name = "Matt Mulls"
                };
                context.Users.Add(spot);
                context.SaveChanges();   // This will add a UserID to the Reviewer object

                review = new Review
                {
                    InstrumentName = "Bach Stradivarius Bb trumpet",
                    InstrumentType = "Trumpet",
                    Rating = 5,
                    ReviewText = "Bestest trumpet for a high schooler! So loud, big sound!",
                    Reviewer = spot,
                    ReviewDate = new DateTime(2020, 7, 4)
                };
                context.Reviews.Add(review);

                // My next two reviews will be by the same user, so I will create
                // the user object once and store it so that both reviews will be
                // associated with the same entity in the DB.

                Reviewer meganCat = new Reviewer()
                {
                    UserName = "Megan cat",
                    Name = "Megan Smith"
                };
                context.Users.Add(meganCat);
                context.SaveChanges();   // This will add a UserID to the reviewer object

                review = new Review
                {
                    InstrumentName = "Conn 8D horn",
                    InstrumentType = "French horn",
                    Rating = 4,
                    ReviewText = "Great standard horn, plays mellow and easy.",
                    Reviewer = meganCat,
                    ReviewDate = new DateTime(2020, 12, 1)
                };
                context.Reviews.Add(review);

                review = new Review
                {
                    InstrumentName = "Yamaha 201",
                    InstrumentType = "Euphonium",
                    ReviewText = "Good sound, wish it took a large-shank mouthpiece.",
                    Rating = 3,
                    Reviewer = meganCat,
                    ReviewDate = new DateTime(2019, 12, 2)
                };
                context.Reviews.Add(review);

                // Stores all the seeded reviews in the database
                context.SaveChanges();
            }
        }
    }
}
