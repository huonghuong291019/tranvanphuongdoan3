using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace tranvanphuongdoan3.Models.DataAccess
{
    public class DataContext
    {
        // = new SqlConnection();
        public string constr = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        SqlConnection con;
        public DataContext()
        {
            con = new SqlConnection(constr);
        }
        public DataTable getData(string sql)//lấy DL từ CSDL đưa về datatable
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, constr);//câu lệnh sql cần lệnh, chuỗi kết nối
            da.Fill(dt);
            return dt;
        }
        public DataView FillData(DataTable dt, string dk)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = dk;
            return dv;
        }
        public void MoKetNoi()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        public void DongKetNoi()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }
        public void StoreNonQuery(string tenStore, params object[] giatri)
        {
            MoKetNoi();
            SqlCommand cm;
            try
            {
                cm = new SqlCommand(tenStore, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                {
                    cm.Parameters[i].Value = giatri[i - 1];
                }
                cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable StoreReader(string tenStore, params object[] giatri)
        {
            DataTable r = new DataTable();
            MoKetNoi();
            SqlCommand cm;

            try
            {
                cm = new SqlCommand(tenStore, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                {
                    cm.Parameters[i].Value = giatri[i - 1];
                }
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.Fill(r);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return r;
        }

    }
}