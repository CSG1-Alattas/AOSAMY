using AOSAMY.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace AOSAMY.Controllers
{
    public class UserController : Controller
    {
        DbAOSAMYContext db=new DbAOSAMYContext();
        //public UserController(IHostingEnvironment host)
        //{
        //    _host = host;
        //}
        //readonly IHostingEnvironment _host; 


        public IActionResult Index()
        {
            return View();
        }
        //Get
        public IActionResult LogIn()
        {
            //IEnumerable<UserInfo> Listusers = db.UserInfos.ToList();

            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(UserInfo userInfo)
        {
            var user = db.UserInfos.FirstOrDefault(u => u.Email == userInfo.Email && u.Password == userInfo.Password );

            if (user == null)
            {
                return NotFound();
            }


            return RedirectToAction("UserPage", new { id = user.Id });
        }
        //Get
        public IActionResult Singnin()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Singnin(UserInfo userInfo)
        {
            var user = db.UserInfos.FirstOrDefault(u => u.Email == userInfo.Email );
            if(user == null)
            {
                //string fileName = string.Empty;
                if (userInfo.clientFile != null)
                {
                    //string MyUpload = Path.Combine(_host.WebRootPath, "img");
                    //fileName =userInfo.clientFile.FileName;
                    //string fullPath = Path.Combine(MyUpload, fileName);
                    //userInfo.clientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    //userInfo.
                    MemoryStream stream = new MemoryStream();
                    userInfo.clientFile.CopyTo(stream);
                    userInfo.Img = stream.ToArray();
                }
                db.UserInfos.Add(userInfo);
                db.SaveChanges();
                return RedirectToAction("LogIn");
            }
            else
            {
                return View(userInfo);
            }

        }
        //Get
        public IActionResult UserPage(int? Id)
        {
            
            if(Id == null)
            {
                return View("Login");
            }
            var userInfo = db.UserInfos.Include(u => u.Products).FirstOrDefault(u => u.Id == Id);
            if (userInfo == null)
            {
                return View("Login");
            }

            return View(userInfo);
        }
    }
}
