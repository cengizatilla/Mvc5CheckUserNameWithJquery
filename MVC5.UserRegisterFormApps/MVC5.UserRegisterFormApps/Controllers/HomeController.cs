using MVC5.UserRegisterFormApps.Models.Entities;
using MVC5.UserRegisterFormApps.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.UserRegisterFormApps.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            RegisterUser newUser = new RegisterUser();
            return View(newUser);
        }

        [HttpPost]
        public ActionResult Index(RegisterUser userForm)
        {
            outputResult<RegisterUser> resultVal = null;
            userForm.ID = Guid.NewGuid();
            userForm.createdDate = DateTime.Now;
            userForm.activationCode = userForm.ID.ToString("N").ToUpper();
            
            using (RegisterUserService registerUserOperation = new RegisterUserService())
            {
                resultVal = registerUserOperation.addNewUser(userForm);
            }

            return View(userForm);
        }
    }
}