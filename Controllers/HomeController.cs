
using Microsoft.AspNetCore.Mvc;
using proyectoTienda.Models;
using proyectoTienda.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
namespace proyectoTienda.Controllers
{

  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
      _logger = logger;
      _context = context;
    }

    public IActionResult Index(int? categoriaId)
    {
      // Consulta los últimos 4 productos de categoría Jeans (2) o Polos (1)
      // Consulta los últimos 4 productos de categoría Jeans (2) o Polos (1)
      var productos = categoriaId == null
          ? _context.Productos.ToList()
          : _context.Productos.Where(p => p.IDCategoria == categoriaId).ToList();

      var categorias = _context.Categorias.ToList(); // Consulta las categorías
      ViewBag.Categorias = categorias;

      return View(productos);
    }


    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
