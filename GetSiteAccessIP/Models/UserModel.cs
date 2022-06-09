using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetSiteAccessIP.Models
{
    
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class SessionUserModel
    {
        public int id { get; set; }
        public string UserName { get; set; }
    }


}