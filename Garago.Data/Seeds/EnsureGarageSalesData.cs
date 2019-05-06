using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Garago.Domain;

namespace Garago.Data.Seeds
{
    public static class EnsureGarageSalesData
    {
        public static void Seed(GaragoContext context)
        {
            /*
            foreach(var gs in context.GarageSales)
            {
                var randomNumOfDays = new Random().Next(20);
                gs.DateOfSale = DateTime.Now.Date.AddDays(randomNumOfDays);
                context.Update(gs);
                context.SaveChanges();
            }
            */
            if (context.GarageSales.FirstOrDefault() == null)
            {   
                var userIds = new Guid[]
                {
                Guid.Parse("07f36cc1-7bff-4802-9577-c7deeb240cd5"),
                Guid.Parse("09aec957-0960-4863-b660-9ceae3bc2381"),
                Guid.Parse("0fbd5b75-7891-4e51-8235-f76809f41e0b"),
                Guid.Parse("1aba420f-fb8c-4c19-b482-d31667800026"),
                Guid.Parse("293ca002-3a84-430c-98ef-071c1b8a1730"),
                Guid.Parse("40fdf249-4102-4f15-b51c-c063d8180aca"),
                Guid.Parse("3be8c558-07c4-403f-8f1c-edd205bd7d38"),
                Guid.Parse("07f36cc1-7bff-4802-9577-c7deeb240cd5"),
                Guid.Parse("4e65af4e-26a5-4960-8d52-dd764294a151"),
                Guid.Parse("4f852216-2e34-4aa1-af82-55d6e8d6ad5e"),
                Guid.Parse("6eba464f-aa3c-469e-a39e-466f4bc3e9b1"),
                Guid.Parse("70364d53-0b2f-4013-8c81-0e38b27f0856"),
                Guid.Parse("735c6af7-244f-4a9e-be19-3c5fa19d1d71"),
                Guid.Parse("7827c68d-d2d6-41f8-901f-7b43334c01ff"),
                Guid.Parse("7a076533-8ff6-45a3-b7af-f64da95340bf"),
                Guid.Parse("91436c61-a71a-4e36-b619-23c1000c043c"),
                Guid.Parse("a26a0257-b3dc-47d0-8aea-ab2d6c912698"),
                Guid.Parse("84a213d5-3750-4d6a-a13a-214c21cbecfa")
            };

                for (var i = 0; i < 100; i++)
                {
                    var userRandomNum = new Random().Next(18);
                    var randomNum = new Random().Next(140);

                    GarageSale newGarageSale1 = new GarageSale(
                                                    title: $"Random Title {randomNum}",
                                                    createdBy: userIds[userRandomNum],
                                                    products: "[]",
                                                    reviews: "[]",
                                                    chats: "[]",
                                                    adImage: "https://tse3.mm.bing.net/th?id=OIP.wBOGSL71nJoLfyvzYnum4AHaFj&pid=15.1&P=0&w=233&h=175",
                                                    description: "Sample Description " + i,
                                                    location: "Tallahasee, FL",
                                                    dateOfSale: DateTime.Now.AddDays(10 + 1),
                                                    isNew: true,
                                                    isUpdated: false
                                                 );

                   context.GarageSales.AddAsync(newGarageSale1);
                }

                context.SaveChangesAsync();
            }
        }
    }
}
