using Microsoft.AspNetCore.Mvc;
using AOSAMY.Models;
using Microsoft.EntityFrameworkCore;

namespace AOSAMY.Controllers
{
    public class goodsController : Controller
    {
        DbAOSAMYContext db = new DbAOSAMYContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Apps()
        {
            IEnumerable<Product> products = db.Products.Where(x=> x.TypeProductid ==4).Include(c => c.UserLog).ToList();

            return View(products);
        }

        public IActionResult Books()
        {
            IEnumerable<Product> products = db.Products.Where(x => x.TypeProductid == 6).Include(c => c.UserLog).ToList();

            return View(products);
        }

        public IActionResult Others()
        {
            IEnumerable<Product> products = db.Products.Where(x => x.TypeProductid == 7).Include(c => c.UserLog).ToList();
             return View(products); 

            
        }
        public IActionResult Template()
        {
            IEnumerable<Product> products = db.Products.Where(x => x.TypeProductid == 2).Include(c => c.UserLog).ToList();
            return View(products);
        }
        public IActionResult Websites()
        {
            IEnumerable<Product> products = db.Products.Where(x => x.TypeProductid == 5).Include(c => c.UserLog).ToList();
            return View(products);
        }  
        public IActionResult Fonts()
        {
            IEnumerable<Product> products = db.Products.Where(x => x.TypeProductid == 5).Include(c => c.UserLog).ToList();

            return View(products);
        }
    }
}
