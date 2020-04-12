using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.UserRegisterFormApps.Models.Entities
{
    public class outputResult<T>:outputBase
    {
        public T dataItem { get; set; }
      
    }
}