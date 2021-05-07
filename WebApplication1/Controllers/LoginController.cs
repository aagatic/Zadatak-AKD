using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {

        private knjigeEntities1 db = new knjigeEntities1();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Auth(WebApplication1.Models.Login loginModel)
        {
            var user = db.Logins.Where(x => x.username == loginModel.username && x.password == loginModel.password).FirstOrDefault();
            if(user == null)
            {  
                loginModel.error = "Neispravan username ili password";
                return View("Index", loginModel);
            }
            else
            {
                Session["userID"] = user.id;
                Session["username"] = user.username;
                return RedirectToAction("Index", "Knjiga");
            }

                
                return View();
        }
        public ActionResult Logout()
        {
            int userID = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}