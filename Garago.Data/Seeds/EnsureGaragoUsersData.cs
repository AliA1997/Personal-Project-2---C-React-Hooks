using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Garago.Domain;
using Garago.Instructure;
using Garago.Domain.User;
using Microsoft.AspNetCore.Identity;

namespace Garago.Data.Seeds
{
    public static class EnsureGaragoUsersData
    {
        public static void Seed(GaragoContext context)
        {
            var names = new List<string>()
            {
                "Ali", "Mike", "Qassem", "Al", "Jasmine", "Curtis", "Lebron James", "Kobe", "D-Wade", "Chris Paul", "Blake Griffin",
                "DeAndre Jordan", "Lou Williams", "Regan", "Seller Test", "Buyer Test", "James Harden", "Steph Curry", "Klay Thompson",
                "Souad", "Mohamad", "Adam", "Albert", "Joey"
            };
            var usernames = new List<string>()
            {
                "AliA1997", "AliA1996", "Ali1995", "QA1996", "MoPrada", "MoPrada_1999", "Deema2006", "AQA1997", "QQ1996", "Jaz1998",
                "Seller82", "Sellz12_", "Sellz43_", "Buyerz", "jimBob1960", "billyBob1970", "timothy91", "timCavs", "jimLakers", "bobKnicks",
                "abc1999", "lbj1984", "rogan1966", "joeyDiaz1963", "qa1965"
            };
            if(!context.Roles.Any())
            {
                var roles = Roles.All.Select(role => new IdentityRole { Name = role, NormalizedName = role.ToUpper() });
                context.Roles.AddRange(roles);
                context.SaveChanges();
            }

            if (context.GaragoUsers.FirstOrDefault() == null)
            {
                string userPassword = AuthUtility.HashPassword("Passw0rd-2");
                for (var i = 0; i < 12; i++)
                {
                    var randomNameIndex = new Random().Next(25);

                    GaragoUser user1 = new GaragoUser(
                                                      $"{names[randomNameIndex]}_{i * 2}",
                                                      $"{usernames[randomNameIndex]}_{i}", "alialhaddadAA@outlook.com",
                                                      "http://monumentfamilydentistry.com/wp-content/uploads/2015/11/user-placeholder.png",
                                                      "630 W Virginia St", "FL", 32304, "Tallahassee"
                                                      );

                    GaragoUser user2 = new GaragoUser(
                                                      $"{names[randomNameIndex]}_{i * 3}",
                                                      $"{usernames[randomNameIndex]}_{i + 1}", "devmtnali@gmail.com",
                                                      "https://www.fysiotherapienoordman.nl/wp-content/uploads/user-placeholder.png",
                                                      "9116 Canyon Magic Ave.", "NV", 89129, "Las Vegas"
                                                      );

                    GaragoUser user3 = new GaragoUser(
                                                        $"{names[randomNameIndex]}_{i * 5}",
                                                        $"{usernames[randomNameIndex]}_{i + 2}", "aalhaddad1997@gmail.com",
                                                        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQmNZxADT7Tc0oznG7e55bA-WvkdkV7CLNXtHs9QB1jwJdb-gt",
                                                        "Antilles Ct", "NV", 89117, "Las Vegas"
                                                        );

                    user1.PasswordHash = userPassword;
                    user1.CreatedAt = DateTime.Now;

                    user2.PasswordHash = userPassword;
                    user2.CreatedAt = DateTime.Now;

                    user3.PasswordHash = userPassword;
                    user3.CreatedAt = DateTime.Now;

                    var usersToAdd = new[] { user1, user2, user3 };

                    context.GaragoUsers.AddRange(usersToAdd);

                }


                context.SaveChanges();
            
            }
        }
    }
}
