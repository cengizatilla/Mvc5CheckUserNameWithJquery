using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.UserRegisterFormApps.Models.Entities
{
    public class outputResultList<T>: outputBase
    {

        public List<T> dataList { get; set; }
    }
}