using Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Framework
{

    public static class RegistrationSupport
    {

        public static String username = null;
        public static String user_completename = null;
        public static Boolean IsCorrectUsernameAndPassword(String username, String password)
        {
            Boolean result = true;
            try
            {
                username = username.EscapeString();
                password = password.EscapeString();
                String sql = String.Format("SELECT * FROM Employees WHERE employee_id = '{0}' AND password = '{1}' ", username,  SecuritySupport.Encrypt( password));
                DataTable dt = DataSupport.RunDataSet(sql).Tables[0];
                if (dt.Rows.Count == 0)
                    throw new Exception();

                user_completename = dt.Rows[0]["completename"].ToString();
            }
            catch (Exception)
            {
                result = false;
            }


            return result;
        }
    }
}