using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using tranvanphuongdoan3.Areas.Admin.Models.Entities;

namespace tranvanphuongdoan3.Areas.Admin.Models.DataAccess
{
    public class AccountModel
    {
        private DBContext context = null;
        public AccountModel()
        {
            context = new DBContext();
        }
        public Boolean CheckAcount(string UserName, string Pass)
        {
            DataTable dt = context.StoreReader("St_Acount_Login", UserName, Pass);
            //DataTable dt = context.StoreReader1("St_Acount_Login", "@userName",UserName, "@passWord",Pass);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public void AddAcount(Account c)
        {
            context.ExcuteNonQuery("insert into dangnhap values('" + c.username + "','" + c.pass + "')");
        }
    }
}