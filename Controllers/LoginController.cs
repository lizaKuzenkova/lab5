using lab5.Models;
using lab5.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab5.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login(UserModel userModel) {
            // return "Results Username = " + userModel.Username + " PW = " + userModel.Password;
            SecurityService securiryService = new SecurityService();
            Boolean success = securiryService.Authenticate(userModel);

            if(success) {
                return View("LoginSuccess", userModel);
            } else {
                return View("LoginFailure");
            }
        }
    }
}