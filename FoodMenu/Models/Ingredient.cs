using System;
namespace FoodMenu.Models
{
	public class Ingredient
	{
		public Ingredient()
		{
		}

		public int Id { get; set; }

		public string Name { get; set; }

        public List<DishIngredient>? DishIngredient { get; set; }
    }
}

