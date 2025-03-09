using Microsoft.AspNetCore.Mvc;
using Roids_Web.Data;
using Roids_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Roids_Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Показване на списъка с продукти
        public IActionResult Index()
        {
            var products = _context.Products.ToList(); // Вземаме всички продукти
            return View(products);
        }

        public IActionResult EditAll()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
    

        // Показване на форма за създаване на нов продукт
        public IActionResult Create()
        {
            return View();
        }

        // Създаване на нов продукт
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // Показване на форма за редактиране на съществуващ продукт
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);  // Връщаме продукта към изгледа
        }

        // Редактиране на съществуващ продукт
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound(); // Ако id-то не съвпада с продукта, връща грешка
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();  // Записваме промените
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound(); // Ако продуктът не съществува в базата
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index)); // Пренасочваме към списъка
            }

            return View(product);  // Връщаме отново формата с грешки
        }

        // Проверка дали продуктът съществува в базата данни
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
