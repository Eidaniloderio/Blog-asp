using System.Diagnostics;
using Blog_asp.Data;
using Blog_asp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog_asp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;

            _db = db;
        }

        public IActionResult Index()
        {
            var dados = _db.BlogPosts.ToList();
            return View(dados);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
