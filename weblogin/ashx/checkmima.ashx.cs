using Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using weblogin;

namespace weblogin
{
    /// <summary>
    /// checkmima 的摘要说明
    /// </summary>
    public class checkmima : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string username = context.Request["username"];
            string password = context.Request["password"];
            string conStr = ConfigurationManager.ConnectionStrings["nameg"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                DataTable table = SqlHelper.ExecuteDataTable("select * from T_xuesheng where Name=@Name", new SqlParameter("@Name", username));
                foreach (DataRow row in table.Rows)
                {
                    string name = (string)row["Name"];
                    string password2 = (string)row["Mima"];
                    if (password == password2)
                    {
                        context.Response.SetCookie(new HttpCookie("user", username));
                        context.Response.SetCookie(new HttpCookie("password", password2));
                        context.Response.Write("yes");
                       return;
                    }
                }
                context.Response.Write("no");
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}