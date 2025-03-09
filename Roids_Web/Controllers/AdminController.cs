using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Roids_Web.Data;
using System.Linq;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var faqCount = _context.FAQs.Count();
        var productCount = _context.Products.Count();

        ViewBag.FAQCount = faqCount;
        ViewBag.ProductCount = productCount;

        return View();
    }
}
