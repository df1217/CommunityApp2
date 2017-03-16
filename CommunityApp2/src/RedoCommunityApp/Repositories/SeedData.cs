using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedoCommunityApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RedoCommunityApp.Repositories
{
    public class SeedData
    {
        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDBContext context = app.ApplicationServices.
                GetRequiredService<ApplicationDBContext>();
            string firstName = "Bob";
            string lastName = "Jones";
            string username = firstName + lastName;
            string email = "BobJones@fake.com";
            string password = "testpassword";
            string role = "Repliers";

            UserManager<Member> userManager = app.ApplicationServices.GetRequiredService<UserManager<Member>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();

            if (!context.Messages.Any())
          {

                {
                    Member user = await userManager.FindByNameAsync(username);
                    if (user == null)
                    {
                        user = new Member { FirstName = firstName, LastName = lastName, UserName = username, Email = email };
                        IdentityResult result = await userManager.CreateAsync(user, password);
                        if (await roleManager.FindByNameAsync(role) == null)
                        {
                            await roleManager.CreateAsync(new IdentityRole(role));
                            if (result.Succeeded)
                            {
                                await userManager.AddToRoleAsync(user, role);
                            }
                        }
                    }

                    context.Members.Add(user);

                context.Messages.AddRange(
                 new Message
                 {
                     Subject = "Fun",
                     Date = DateTime.Parse("1/1/1937"),
                     Body = "Code is fun",
                     From = user,
                     Topic = "code"
                 }
                 );

                   member = new Member
                {
                    Name = "John Smith",
                    Email = "jsmith@fake.com"
                };
                context.Members.Add(member);

                context.Messages.AddRange(
                 new Message
                 {
                     Subject = "sql",
                     Date = DateTime.Parse("1/1/1937"),
                     Body = "sql is war",
                     From = member,
                     Topic = "database"
                 }
                 );

                 member = new Member
                {
                    Name = "Jane Smith",
                    Email = "jasmith@fake.com"
                };
                context.Members.Add(member);

                context.Messages.AddRange(
                 new Message
                 {
                     Subject = "fun",
                     Date = DateTime.Parse("1/1/1937"),
                     Body = "Database is fun",
                     From = member,
                     Topic = "database"
                 }
                 );

                context.Messages.AddRange(new Message
                {
                    Subject = "database fun",
                    Date = DateTime.Parse("1/1/1937"),
                    Body = "Database is fun if you want it to be",
                    From = member,
                    Topic = "database"
                }
                    );

                



           }
            context.SaveChanges();
        }

    }
}
