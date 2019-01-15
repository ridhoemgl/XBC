using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XBC.MVC.WebApp.Security
{
    public static class SessionPersister
    {
        static string varUserIdSession = "1";
        static string varUserNameSession = "username";
        static string varFullNameSession = "fullname";

        public static string UserId {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;

                var sessionVar = HttpContext.Current.Session[varUserIdSession];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }

            set
            {
                HttpContext.Current.Session[varUserIdSession] = value;
            }
        }

        public static string UserName
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;

                var sessionVar = HttpContext.Current.Session[varUserNameSession];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }

            set
            {
                HttpContext.Current.Session[varUserNameSession] = value;
            }
        }

        public static string FullName
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;

                var sessionVar = HttpContext.Current.Session[varFullNameSession];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }

            set
            {
                HttpContext.Current.Session[varFullNameSession] = value;
            }
        }
    }
}