namespace PhotoAlbum.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoAlbum.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhotoAlbum.Models.ApplicationDbContext context)
        {
            context.Database.ExecuteSqlCommand("delete from Albums");

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(userStore);
            

            var albums = new Album[]
            {
                new Album
                {
                    Title = "Monterey Trip",
                     Description = "My trip to Monterey, CA",
                     ApplicationUserId = user.Id,
                     //ApplicationUser = user,
                     Photos = new List<Photo>()
                     {
                        new Photo {
                                Title = "Otter",
                                Description ="CUTE otter at the aquarium.",
                                Rating = 5,
                                PhotoUrl = " https://www.facebook.com/photo.php?fbid=24689177156&set=a.24617132156.37152.557232156&type=3&theater"
                        },
                        new Photo {
                                Title = "Jelly Fish",
                                Description ="Peaceful jelly fish.",
                                Rating = 5,
                                PhotoUrl = "https://www.facebook.com/photo.php?fbid=24688892156&set=a.24617132156.37152.557232156&type=3&theater"
                        },
                        new Photo {
                                Title = "Penguins",
                                Description ="Adorable penguins.",
                                Rating = 5,
                                PhotoUrl = "https://www.facebook.com/photo.php?fbid=24689517156&set=a.24689297156.37240.557232156&type=3&theater"
                        }
                     }
                }
            };
            context.Albums.AddOrUpdate(a => a.Title, albums);
        }
    }
}