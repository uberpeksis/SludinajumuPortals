using Logic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SludinajumuPortals
{
    public static class SessionExtension
    {
        public static bool IsLogged(this HttpSessionStateBase session)
        {
            if (session["user"] == null)
            {
                return false;
            }
            return true;

            //vai visu var šādi:
            // return session["user"] != null;
        }

        public static void SetUser(this HttpSessionStateBase session, UserData user)
        {
            session["user"] = user;
        }

        public static UserData GetUser(this HttpSessionStateBase session)
        {
            return (UserData)session["user"];
        }

    }
}