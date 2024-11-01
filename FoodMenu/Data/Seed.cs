using System;
using FoodMenu.Models;
using System.Linq;

namespace FoodMenu.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                // Dishes
                var dishesToAdd = new List<Dish>
                {
                    new Dish { Name = "Pepperoni Pizza", Price = 6.50, ImageUrl = "https://assets-us-01.kc-usercontent.com/4353bced-f940-00d0-8c6e-13a0a4a7f5c2/2ac60829-5178-4a6e-80cf-6ca43d862cee/Quick-and-Easy-Pepperoni-Pizza-700x700.jpeg?w=1280&auto=format" },
                    new Dish { Name = "Salad Pizza", Price = 6.70, ImageUrl = "https://www.lastingredient.com/wp-content/uploads/2019/08/mixed-greens-salad-pizza1.jpg" },
                    new Dish { Name = "Pineapple Pizza", Price = 5.80, ImageUrl = "https://static01.nyt.com/images/2023/03/29/multimedia/23HAMREX2-pineapple-ham-pizza-qwct/HAMREX2-pineapple-ham-pizza-qwct-superJumbo.jpg" },
                    new Dish { Name = "Cheese Burger", Price = 3.50, ImageUrl = "https://www.sargento.com/assets/Uploads/Recipe/Image/GreatAmericanBurger__FillWzExNzAsNTgzXQ.jpg" },
                    new Dish { Name = "Seafood Boil", Price = 30.00, ImageUrl = "https://www.butterbeready.com/wp-content/uploads/2023/06/DK6A2439.jpg" },
                    new Dish { Name = "Beef Burger", Price = 5.50, ImageUrl = "https://www.unileverfoodsolutions.co.za/dam/global-ufs/mcos/SOUTH-AFRICA/calcmenu/recipes/ZA-recipes/general/beef-burger/main-header.jpg" },
                    new Dish { Name = "Fries and Chicken", Price = 8.50, ImageUrl = "https://laromapizzadallas.com/wp-content/uploads/2023/04/6d88062c-a687-41fe-9ee5-f6b306adabee.jpg" }
                };

                foreach (var dish in dishesToAdd)
                {
                    if (!context.Dishes.Any(d => d.Name == dish.Name))
                    {
                        context.Dishes.Add(dish);
                    }
                }
                context.SaveChanges();

                // Ingredients
                var ingredientsToAdd = new List<Ingredient>
                {
                    new Ingredient { Name = "Pepperoni" },
                    new Ingredient { Name = "Cheese" },
                    new Ingredient { Name = "Beef" },
                    new Ingredient { Name = "Pineapple" },
                    new Ingredient { Name = "Crab" },
                    new Ingredient { Name = "Lobster" },
                    new Ingredient { Name = "Oysters" },
                    new Ingredient { Name = "Potato" },
                    new Ingredient { Name = "Chicken" },
                    new Ingredient { Name = "Lettuce" },
                    new Ingredient { Name = "Onion" },
                    new Ingredient { Name = "Spinach" },
                    new Ingredient { Name = "Flour" },
                    new Ingredient { Name = "Buns" }
                };

                foreach (var ingredient in ingredientsToAdd)
                {
                    if (!context.Ingredients.Any(i => i.Name == ingredient.Name))
                    {
                        context.Ingredients.Add(ingredient);
                    }
                }
                context.SaveChanges();

                // DishIngredients
                var dishIngredientsToAdd = new List<DishIngredient>
                {
                    new DishIngredient { DishId = 2, IngredientId = 1 },
                    new DishIngredient { DishId = 2, IngredientId = 2 },
                    new DishIngredient { DishId = 3, IngredientId = 11 },
                    new DishIngredient { DishId = 3, IngredientId = 12 },
                    new DishIngredient { DishId = 3, IngredientId = 13 },
                    new DishIngredient { DishId = 3, IngredientId = 1 },
                    new DishIngredient { DishId = 3, IngredientId = 14 },
                    new DishIngredient { DishId = 4, IngredientId = 5 },
                    new DishIngredient { DishId = 4, IngredientId = 14 },
                    new DishIngredient { DishId = 5, IngredientId = 15 },
                    new DishIngredient { DishId = 5, IngredientId = 14 },
                    new DishIngredient { DishId = 5, IngredientId = 3 },
                    new DishIngredient { DishId = 6, IngredientId = 6 },
                    new DishIngredient { DishId = 6, IngredientId = 7 },
                    new DishIngredient { DishId = 6, IngredientId = 8 },
                    new DishIngredient { DishId = 6, IngredientId = 2 },
                    new DishIngredient { DishId = 7, IngredientId = 15 },
                    new DishIngredient { DishId = 7, IngredientId = 14 },
                    new DishIngredient { DishId = 7, IngredientId = 4 },
                    new DishIngredient { DishId = 8, IngredientId = 9 },
                    new DishIngredient { DishId = 8, IngredientId = 10 },
                    new DishIngredient { DishId = 7, IngredientId = 11 },
                    new DishIngredient { DishId = 7, IngredientId = 12 },
                    new DishIngredient { DishId = 7, IngredientId = 13 }
                };

                foreach (var dishIngredient in dishIngredientsToAdd)
                {
                    if (!context.DishIngredients.Any(di => di.DishId == dishIngredient.DishId && di.IngredientId == dishIngredient.IngredientId))
                    {
                        context.DishIngredients.Add(dishIngredient);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
