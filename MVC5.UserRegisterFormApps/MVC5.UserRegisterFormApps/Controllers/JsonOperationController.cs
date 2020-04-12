using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.UserRegisterFormApps.Controllers
{
    public class JsonOperationController : Controller
    {
        public JsonResult checkUserName(string userNameVal)
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}