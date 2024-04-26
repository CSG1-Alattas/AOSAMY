using Microsoft.AspNetCore.Mvc;
using AOSAMY.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AOSAMY.Controllers
{
    
    public class MainController : Controller
    {
        DbAOSAMYContext db= new DbAOSAMYContext();
        //public MainController(DbAOSAMYContext db)
        //{
        //    _db = db;
        //}

        //private readonly DbAOSAMYContext _db;

        //public void NameOfUser(int UserId = 1)
        //{
        //    List<UserInfo> userInfos = _db.UserInfos.ToList();
        //    SelectList listUsers = new SelectList(userInfos, "Id", "Name", UserId);
        //    ViewBag.UserList = listUsers;
        //}
        public IActionResult Index()
        {
            IEnumerable<Product> products = db.Products.Include(c=>c.UserLog).ToList();
       
            return View(products);
        }
    }
}
