using GetSiteAccessIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetSiteAccessIP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
       
            if (this.ModelState.IsValid)
            {
                if(model.UserName=="Admin" && model.Password == "123456")
                {
                    SaveLoginInfo(model);


                    return this.RedirectToAction("Index", "Home");
                }

                return View();
            }

            return View();
        }

        private void SaveLoginInfo(UserModel model)
        {
          // actually you need to get user info from table
            LoginInfo.UserId = "1";//default assign
            LoginInfo.UserName = model.UserName;
           
            // Cookieへも同様に書き出す
            LoginInfo.CookieUserId = "1";
        }
    }
}