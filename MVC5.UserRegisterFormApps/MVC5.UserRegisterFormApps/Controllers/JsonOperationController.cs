using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.UserRegisterFormApps.Controllers
{
    public class JsonOperationController : Controller
    {
        public JsonResult checkEmailAddress(string emailAddressVal)
        {
            Models.Services.RegisterUserService userService = new Models.Services.RegisterUserService();
            var result = userService.checkEmailAddres(emailAddressVal);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}