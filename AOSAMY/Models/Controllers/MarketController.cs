using Microsoft.AspNetCore.Mvc;
using AOSAMY.Models;
using Microsoft.EntityFrameworkCore;

public class MarketController : Controller
    {
    DbAOSAMYContext db = new DbAOSAMYContext();
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Shops(UserInfo userInfo)
        {
        IEnumerable<UserInfo> UserList = db.UserInfos.ToList();
            return View(UserList);
        }
        public IActionResult ProductView(int? Id)
        {   
            if(Id == null || Id == 0)
            {
            return NotFound();
            }
            var product = db.Products.Find(Id);
            
            if(product == null)
            {
            return NotFound();
            }

            return View(product);
        }

        public IActionResult MarkteUser(int? Id)
        {
        if (Id == null || Id == 0)
        {
            return NotFound();
        }
         var userInfo = db.UserInfos.Include(u => u.Products).FirstOrDefault(u => u.Id == Id);

        if (userInfo == null)
        {
            return NotFound();
        }

        return View(userInfo);
    }
    }

