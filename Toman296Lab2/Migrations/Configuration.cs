namespace Toman296Lab6.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;


    internal sealed class Configuration : DbMigrationsConfiguration<Toman296Lab6.Models.Toman296Lab2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Toman296Lab6.Models.Toman296Lab2Context";
        }

        protected override void Seed(Toman296Lab6.Models.Toman296Lab2Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            Member firstMember = new Member { Email = "samantha.toman@gmail.com", UserName = "tomansc" };
            Member secondMember = new Member { Email = "macaroni@cheese.com", UserName = "mcgillavroy" };
            context.Users.AddOrUpdate(m => m.UserName, firstMember, secondMember);
            context.SaveChanges();

            Message m1 = new Message { Topic = "Garage sale", Date = new DateTime(2016, 2, 10), MessageID = 11, MemberID = firstMember.Id, Body = "Does anyone need llama pelts, matroyshka dolls, Trapper Keepers in mint condition, or other odd tchotchkes? Come on down to the Elks Club this Saturday for bizarre knick-knacks odder than anything your imagination can conjure up.", Subject = "Sale: Weird and Delightful Goods -- for Cheap!" };
            Message m2 = new Message { Topic = "Neighborhood watch", Date = new DateTime(2016, 1, 30), MessageID = 12, MemberID = secondMember.Id, Body = "There have been Sasquatch sightings reported all around Sudden Valley. Grab your cameras, a six-pack of micro-cans from Hop Snobbery Brewery, and get ready to place some bets with your neighbors as we all doubt our sanity for an afternoon.", Subject = "Sasquatch Watch THIS SATURDAY" };
            Message m3 = new Message { Topic = "Volunteer", Date = new DateTime(2016, 3, 14), MessageID = 13, MemberID = secondMember.Id, Body = "Come on down to the Bellingham Farmers' Market in March to volunteer at PoultryFest. Volunteers are needed particularly for the chicken fashion show.", Subject = "PoultryFest seeking volunteers" };
            Message m4 = new Message { Topic = "Skills share", Date = new DateTime(2016, 4, 2), MessageID = 14, MemberID = firstMember.Id, Body = "WCC is looking to host a series of night classes on programming basics, and what better way to dive in than to make your own website? Bring snacks.", Subject = "Pro bono programming courses -- make a website!" };

            ForumView f1 = new ForumView();
            f1.LastModified = DateTime.Now;
            f1.ForumID = 321;
            f1.ForumName = "Test forum for Bellingham site";
            f1.Messages.Add(m1);
            f1.Messages.Add(m2);
            f1.Messages.Add(m3);
            f1.Messages.Add(m4);
            context.Messages.AddOrUpdate(m => m.Topic, m1, m2, m3, m4);
            context.ForumViews.AddOrUpdate(f => f.ForumName, f1);

            var manager = new UserManager<Member>(
                new UserStore<Member>(context));

            var user = new Member { UserName = "testUser2", Email = "test@user.com" };
            manager.Create(user, "password2");
            context.Users.AddOrUpdate(u => u.UserName, user); // Changing it to the duplicated att. worked.

            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole
            {
                Name = "Admin, MegaAdmin, User"
            });

            SaveChanges(context);
            manager.AddToRole(user.Id, "Admin");
            manager.AddToRole(user.Id, "MegaAdmin");
            manager.AddToRole(user.Id, "User");
            // http://stackoverflow.com/questions/24389126/mvc5-usermanager-addtorole-error-adding-user-to-role-userid-not-found
        }

        private static void SaveChanges(DbContext context) // Thanks to Brody for finding a link providing this.
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }
        }
    }
}
