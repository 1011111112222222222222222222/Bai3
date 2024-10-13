using Microsoft.AspNetCore.Mvc;
using Hoa.Models;
namespace Hoa.Controllers
{
    public class ProductController : Controller
    {
        QlSpContext data =  new QlSpContext();  
        public IActionResult Index()
        {
            var all = from t in data.Products select t;
            return View(all);
        }
        public IActionResult Details(int id)
        {
            var t = data.Products.Where(t => t.Masp == id).FirstOrDefault();
            return View(t);
        }
    }
}
