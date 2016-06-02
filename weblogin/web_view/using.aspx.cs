using Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2;

namespace WebApplication2
{
    public partial class _using : System.Web.UI.Page
    {
        public DataTable tables;
        public string ;
        public string name;
        public string mima;
        public string xuehao;
        public string xingming;
        public string shenfengzhen;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "text/html";
            HttpCookie cookie = Request.Cookies["user"];
            HttpCookie login = Request.Cookies["password"];
            username = cookie.Value;
            string password = login.Value;

            string conStr = ConfigurationManager.ConnectionStrings["nameg"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                //if (vip == "1")

                DataTable table = SqlHelper.ExecuteDataTable("select * from T_xuesheng where Name=@Name", new SqlParameter("@Name", username));
                //{
                tables = SqlHelper.ExecuteDataTable("select * from T_xuesheng ");
                int a = table.Rows.Count;
                DataRow row = table.Rows[a - 1];
                {


                    name = (string)row["Name"];
                    mima = (string)row["Mima"];
                    xingming = Convert.ToString(row["Xingming"]);
                    xuehao = Convert.ToString(row["Xuehao"]);
                    shenfengzhen = Convert.ToString(row["Shenfengzhen"]);
                }
                //}
                //else {
                //    tables = Sqlhelper.ExecuteDataTable("select * from T_xuesheng where Name=@Name", new SqlParameter("@Name", username));
                //}
            }
        }
    }

}
