using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Garago.Domain;

namespace Garago.Data.Seeds
{
    public static class EnsureProductsData
    {
        public static async Task Seed(GaragoContext context)
        {
            string[] possibleTitles = new string[]
            {
                "Javascipt Mug", "Python TShirt", "Gnome", "Javascript TShirt",
                "Apple IPhone 5", "Macbook", "HTML5 TShirt","Gucci Shirt",
                "Wayne Grestky Jersey", "Jason Kidd Jersey", "Lebron James Jersey", "Dwyane Wade Jersey",
                "Spalding Basketball",  "2005 Honda Civic", "2000 Saturn L300", "2005 Honda Accord",
                "Levi's Pants", "Jordan 1's", "Ronaldo Jersey", "Messi Jersey"
            };

            string[] possibleImages = new string[]
            {
                "https://images-na.ssl-images-amazon.com/images/I/41r8kwPqlyL._SX425_.jpg",
                "https://m.media-amazon.com/images/I/A13usaonutL._CLa%7C2140,2000%7C71Fru202q3L.png%7C0,0,2140,2000+0.0,0.0,2140.0,2000.0.png",
                "https://cdn11.bigcommerce.com/s-59t8stv95a/images/stencil/1280x1280/products/1424/1392/agent-double-gnome-7-you-don-t-gno-me-3__63103.1527617597.jpg?c=2&imbypass=on",
                "https://devstickers.com/assets/img/pro/tee/u967_mens.png",
                "https://i5.walmartimages.com/asr/f9e250ef-25a7-49f5-8a35-91b0b7db674b_1.7b88014179482d6c81718af86c73e71d.jpeg",
                "https://icdn2.digitaltrends.com/image/macbook-air-2018-focus-1500x1000.jpg",
                "https://html5shirt.com/img/ath-front-large.jpg",
                "https://media.gucci.com/style/DarkGray_Center_0_0_800x800/1547487904/457095_X5L89_9234_001_100_0000_Light-Oversize-T-shirt-with-Gucci-logo.jpg",
                "https://images-na.ssl-images-amazon.com/images/I/81SWuNaQaOL._SX425_.jpg",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTvmNOe968bEi4WSM6Xfc67EC5Xc3uKj_xftrd2z5zr3phCVLHOvQ",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR0BlzePZgQvX9Q6LqcOoAIvK2s7iOFrxpm4v3dTyzuIMpt9ms27A",
                "http://www.storeheatonline.com/173-large/adidas-dwyane-wade-miami-heat-swingman-on-home-jersey-white.jpg",
                "https://images-na.ssl-images-amazon.com/images/I/A1ser-udbFL._SX466_.jpg",
                "https://images.hgmsites.net/lrg/2005_honda_civic_gx_100008113_l.jpg",
                "http://consumerguide.com/wp-content/uploads/2014/07/01130001990003.jpg",
                "http://4-photos7.motorcar.com/used-2005-honda-accord_sedan-lxautomatic-12402-18310930-2-1024.jpg",
                "https://cdn.ccs.com/media/catalog/product/cache/4/image/9df78eab33525d08d6e5fb8d27136e95/l/e/levi-s-skate-work-se-pants-cabernet-1_13.1506873608.jpg",
                "https://images-na.ssl-images-amazon.com/images/I/81gg7SQxIZL._UX395_.jpg",
                "https://i.pinimg.com/originals/16/20/ec/1620ec754a444b601417ef3fd24b760b.jpg",
                "https://fanatics.frgimages.com/FFImage/thumb.aspx?i=/productimages/_3195000/ff_3195227_full.jpg&w=600",
            };

            double[] possiblePrices = new double[]
            {
                12.00, 23.00, 2.00, 21.00,
                25.00, 21.00, 15.00, 12.543,
                5.00, 10.00, 20.00, 30.00,
                12.74, 30.24, 25.00, 50.00,
                75.00, 50.50, 7.50, 11.25
            };

            Guid[] garageSalesIds = new Guid[]
            {
                Guid.Parse("08d6b4b8-8045-9b8c-245e-57e69706964d"), Guid.Parse("08d6b4b8-8045-c715-e15c-fe1d64ad78f4"),
                Guid.Parse("08d6b4b8-8045-a0b6-3a30-68093d0adefb"), Guid.Parse("08d6b4b8-8045-cb33-9f76-cdbce609c5db"),
                Guid.Parse("08d6b4b8-8045-a53f-e3c0-5eedeecfaf24"), Guid.Parse("08d6b4b8-8045-ce31-2f33-3496b9211878"),
                Guid.Parse("08d6b4b8-8045-a94e-fefa-40e0cd393d6a"), Guid.Parse("08d6b4b8-8046-2f94-9fd4-63c31e26206f"),
                Guid.Parse("08d6b4b8-8045-aed9-cc1d-eeba6f028fef"), Guid.Parse("08d6b4b8-8046-33c7-e284-814dd8592c83"),
                Guid.Parse("08d6b4b8-8045-b2b9-c4eb-d328d383697f"), Guid.Parse("08d6b4b8-8046-3687-1c09-f9a8e1b7973c"),
                Guid.Parse("08d6b4b8-8045-b733-9e8c-95435c5f4ab9"), Guid.Parse("08d6b4b8-8046-393d-d017-831008b3990d"),
                Guid.Parse("08d6b4b8-8045-ba9d-734e-58bc0d2e567d"), Guid.Parse("08d6b4b8-8046-4ada-e44a-6c6faeba27f0"),
                Guid.Parse("08d6b4b8-8045-bf12-091d-1302a8dabc06"), Guid.Parse("08d6b4b8-8046-4df1-af00-82c9c922a72a"),
                Guid.Parse("08d6b4b8-8045-c2ed-626a-713c5c407187"), Guid.Parse("08d6b4b8-8046-5055-d4c5-50c0f9b69755")
            };

            if (context.Products.FirstOrDefault() == null)
            {

                for (var i = 0; i < 50; i++)
                {
                    //Generate a random number so each product will be different
                    int randomTitleNum = new Random().Next(20);
                    int randomPriceNum = new Random().Next(20);
                    int randomGarageSaleIdNum = new Random().Next(20);

                    Product newProduct1 = new Product(
                                            title: possibleTitles[randomTitleNum],
                                            image: possibleImages[randomTitleNum],
                                            price: possiblePrices[randomPriceNum],
                                            description: "Test Description",
                                            garageSaleId: garageSalesIds[randomGarageSaleIdNum],
                                            isNew: true,
                                            isUpdated: false
                                            );
                    await context.AddAsync(newProduct1);
                }

                await context.SaveChangesAsync();

            }
        }
    }
}
