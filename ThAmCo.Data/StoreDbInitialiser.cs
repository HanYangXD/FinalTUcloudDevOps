using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producks.Data
{
    public static class StoreDbInitialiser
    {
        public static async Task SeedTestData(StoreDb context,
                                              IServiceProvider services)
        {
            if (context.Products.Any())
            {
                //db seems to be seeded
                return;
            }

            var categories = new List<Category>
            {
                new Category { Name = "Covers", Description = "Davison Stores pride ourselves on our poor range of covers for your mobile device at premium prices.  If you're lukcy your phone or tablet will be protected from any dents, scratches and scuffs.", Active = true },
                new Category { Name = "Case", Description = "Browse our wide range of cases for phones and tablets that will help you to keep your mobile device protected from the elements.", Active = false },
                new Category { Name = "Accessories", Description = "We stock a small range of phone and tablet accessories, including car holders, sports armbands, stylus pens and very little else.", Active = true },
                new Category { Name = "Screen Protectors", Description = "Exclusive Davison Stores screen protectors for your phone or tablet.", Active = true }
            };
            categories.ForEach(c => context.Categories.Add(c));

            var brands = new List<Brand>
            {
                new Brand { Name = "Soggy Sponge", Active = true },
                new Brand { Name = "Damp Squib", Active = false },
                new Brand { Name = "iStuff-R-Us", Active = true }
            };
            brands.ForEach(b => context.Brands.Add(b));

            await context.SaveChangesAsync();

            var products = new List<Product>
            {
                new Product { Active = true, Brand = brands[0], Category = categories[0], Description = "Poor quality fake faux leather cover loose enough to fit any mobile device.", Name = "Wrap It and Hope Cover", Price = 5.99, StockLevel = 1, Rating = 2.26 },
                new Product { Active = true, Brand = brands[1], Category = categories[0], Description = "Purchase you favourite chocolate and use the provided heating element to melt it into the perfect cover for your mobile device.", Name = "Chocolate Cover", Price = 10.97, StockLevel = 0, Rating = 4.32 },
                new Product { Active = true, Brand = brands[2], Category = categories[0], Description = "Lamely adapted used and dirty teatowel.  Guaranteed fewer than two holes.", Name = "Cloth Cover", Price = 3.01, StockLevel = 6, Rating = 4.36 },
                new Product { Active = true, Brand = brands[0], Category = categories[1], Description = "Especially toughen and harden sponge entirely encases your device to prevent any interaction.", Name = "Harden Sponge Case", Price = 9.99, StockLevel = 2, Rating = 3.87 },
                new Product { Active = true, Brand = brands[0], Category = categories[1], Description = "Place your device within the water-tight container, fill with water and enjoy the cushioned protection from bumps and bangs.", Name = "Water Bath Case", Price = 20.0, StockLevel = 3, Rating = 4.53 },
                new Product { Active = false, Brand = brands[0], Category = categories[2], Description = "Keep you smartphone handsfree with this large assembly that attaches to your rear window wiper (Hatchbacks only).", Name = "Smartphone Car Holder", Price = 110.01, StockLevel = 8, Rating = 4.97 },
                new Product { Active = true, Brand = brands[0], Category = categories[2], Description = "Keep your device on your arm with this general purpose sticky tape.", Name = "Sticky Tape Sport Armband", Price = 2.99, StockLevel = 23, Rating = 4.89 },
                new Product { Active = true, Brand = brands[1], Category = categories[2], Description = "Stengthen HB pencils guaranteed to leave a mark.", Name = "Real Pencil Stylus", Price = 0.99, StockLevel = 5, Rating = 4.73 },
                new Product { Active = true, Brand = brands[0], Category = categories[3], Description = "Coat your mobile device screen in a scratch resistant, opaque film.", Name = "Spray Paint Screen Protector", Price = 4.99, StockLevel = 1, Rating = 4.55 },
                new Product { Active = true, Brand = brands[2], Category = categories[3], Description = "For his or her sensory pleasure. Fits few known smartphones.", Name = "Rippled Screen Protector", Price = 7.99, StockLevel = 5, Rating = 3.88 },
                new Product { Active = true, Brand = brands[2], Category = categories[3], Description = "For an odour than lingers on your device.", Name = "Fish Scented Screen Protector", Price = 2.88, StockLevel = 0, Rating = 4.77 },
                new Product { Active = true, Brand = brands[1], Category = categories[3], Description = "Guaranteed not to conduct electical charge from your fingers.", Name = "Non-conductive Screen Protector", Price = 10.0, StockLevel = 10, Rating = 4.88 },
            };
            products.ForEach(p => context.Products.Add(p));

            await context.SaveChangesAsync();
        }
    }
}
