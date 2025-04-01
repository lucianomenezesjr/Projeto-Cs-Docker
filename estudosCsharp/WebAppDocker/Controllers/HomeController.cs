using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppDocker.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAppDocker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Pega 3 produtos mais caros para exibir em destaque
            var produtosDestaque = await _context.Produtos
                .OrderByDescending(p => p.Preco)
                .Take(3)
                .ToListAsync();
            
            return View(produtosDestaque);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            });
        }
    }
}