using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace opr
{
    public static class Extensions
    {
        public static string GetUserId(this string userName)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            return string.Empty;
        }
    }
}