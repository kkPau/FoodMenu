using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodMenu.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodMenu.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index(string searchString)
        {
            var dishes = from d in _context.Dishes select d;
            if (!string.IsNullOrEmpty(searchString))
            {
                dishes = dishes.Where(d => d.Name.Contains(searchString));
                return View(await dishes.ToListAsync());
            }
            return View(await dishes.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var dish = await _context.Dishes.Include(di => di.DishIngredient).ThenInclude(i => i.Ingredient).FirstOrDefaultAsync(x => x.Id == id);
            if (dish == null)
            {
                return View("Not Found");
            }
            return View(dish);
        }
    }
}

