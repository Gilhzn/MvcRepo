using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public static class Common
    {
        public static readonly string BaseApi = ConfigurationManager.AppSettings["BaseApi"];
    }
}