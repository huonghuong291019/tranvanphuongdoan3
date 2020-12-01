using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace tranvanphuongdoan3.Areas.Admin.Models.DataAccess
{
    public class DBContext
    {
        SqlConnection con;// = new SqlConnection();
                          /// <summary>
                          /// kết nối đến cơ sở dữ liệu với quyền Window
                          /// </summary>
                          /// <param name="SV"> Thông tin severName</param>
                          /// <param name="DN">Thông tin về DataName</param>
                          /// 
        // string st = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        string stcon = "";
        public DBContext()
        {
            stcon = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
            con = new SqlConnection(stcon);
        }       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"> dt DataTable cần lọc</param>
        /// <param name="dieukien">Điều kiện lọc</param>
        /// <returns></returns>
        public DataView LocDuLieu(DataTable dt, string dieukien)
        {
            // Buoc 1
            DataView dv = new DataView(dt);
            // Buoc 2
            dv.RowFilter = dieukien;
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
        /// <summary>
        /// Thực thi câu lệnh truy vấn hành động SQL (Insert, Update, Delete)
        /// </summary>
        /// <param name="sqlstring"></param>
        public Boolean ExcuteNonQuery(string sqlstring)
        {
            /* chú ý trong mô hình hướng kết nối thì đối tượng SqlConnection bắt buộc phải được mở
            vì vậy việc gọi phương thức MoKetNoi() là bắt buộc
            */
            //try
            //{
                MoKetNoi();
                SqlCommand cm = new SqlCommand(sqlstring, con);
                cm.ExecuteNonQuery();
                DongKetNoi();
                return true;
            //}

            //catch
            //{
            //    return false;
            //}




        }
        /// <summary>
        /// Thực thi câu lệnh truy vấn SQL Select
        /// </summary>
        /// <param name="sqlstring"></param>
        /// <returns></returns>
        public SqlDataReader ExcuteReader(string sqlstring)
        {
            MoKetNoi();

            SqlCommand cm = new SqlCommand(sqlstring, con);
            SqlDataReader drr = cm.ExecuteReader();
            //   DongKetNoi();
            return drr;

        }


        /// <summary>
        /// Lấy dữ liệu từ cơ sở dữ liệu và fill vào bảng 
        /// </summary>
        /// <param name="sqlSelect">Câu lệnh select</param>
        /// <returns>Bảng mà đã fill dữ liệu vào</returns>
        public DataTable FillDataTable(string sqlSelect)
        {
            //b1: Khai báo đối tượng DataTable
            DataTable dt = new DataTable();
            //B2. Sử dụng đối tượng SqlDataAdapter, truyền vào câu lệnh truy vấn select, thông tin kết nối
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, con);
            // Gọi phương thức Fill để điền dữ liệu vào DataTable.
            da.Fill(dt);
            // Trả về kết quả   
            return dt;
        }
        // Xoa các bản ghi từ DataTable được check


        /// <summary>
        /// Thêm một dòng vào DataTable 
        /// </summary>
        /// <param name="TableName">Tên bảng trong DataSet</param>
        /// <param name="Value">Giá trị của các trường</param>
        /// <returns>Đối tượng DataTable tham chiếu đến bảng vừa được thêm</returns>
        /// 
        public void InsertData(DataTable dt, params object[] Value)
        {
            // Tạo ra một dòng có cấu trúc giống bảng
            DataRow dr = dt.NewRow();
            // Gan gia tri cho tung truong
            for (int i = 0; i < Value.Length; i++)
            {
                dr[i] = Value[i];   // Gán giá trị cho các trường 
            } //them dong vao bang
            dt.Rows.Add(dr);
        }
        /// <summary>
        /// Sửa thông tin một dòng trong Datatable
        /// </summary>
        /// <param name="dt">DataTable cần sử</param>
        /// <param name="NV">Tập hợp các giá trị mới</param>
        public void UpdateRowTable(DataTable dt, params object[] NV)
        {
            // Duyệt qua các row trong DataTable
            for (int d = 0; d < dt.Rows.Count; d++)
            {
                if (dt.Rows[d][0].ToString() == NV[0].ToString())
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        // Sửa thông tin của từng trường trong Row
                        dt.Rows[d][i] = NV[i];
                    }
                    break;
                }
            }
        }
        public void UpadateRowTableV(DataTable dt, string dieukien, params object[] gtm)
        {
            DataView dv = LocDuLieu(dt, dieukien);
            if (dv.Count > 0)
            {
                for (int i = 0; i < gtm.Length; i++)
                    dv[0][i] = gtm[i];
            }
        }

        public void UpdateRowTabldeV(DataTable dt, params object[] NV)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = "MaNV='" + NV[0].ToString() + "'";
            if (dv.ToTable().Rows.Count > 0)
            {
                for (int i = 0; i < dv.ToTable().Columns.Count; i++)
                {
                    dv[0][i] = NV[i];
                }
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="dieukien"></param>
        public void DeleteDataTable(DataTable dt, string Ma)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == Ma)
                {
                    dt.Rows.RemoveAt(i);
                    break;
                }

            }

        }


        ///// <summary>
        ///// mo ta cho no
        ///// </summary>
        ///// <param name="tenStore">Dối vào 1 là Tên của strore</param>
        ///// <param name="giatri"> các đối tự chọn sau là các giá trị cần truyền cho strore</param>

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenStore">Tên của Store procedure</param>
        /// <param name="giatri">Mảng các giá trị truyền vào cho đối số của store</param>
        /// <returns></returns>

        public DataTable StoreReader(string tenStore, params object[] giatri)
        {
            DataTable r = new DataTable();
            SqlCommand cm;
            MoKetNoi();
            try
            {
                cm = new SqlCommand(tenStore, con);
                cm.CommandType = CommandType.StoredProcedure;
                // lấy về các parameter của store add vào cm
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                {
                    cm.Parameters[i].Value = giatri[i - 1];
                }
                new SqlDataAdapter(cm).Fill(r);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return r;
        }

        public DataTable StoreReader1(string tenStore, params object[] Name_giatri)
        {
            DataTable r = new DataTable();
            SqlCommand cm;
            MoKetNoi();
            try
            {
                cm = new SqlCommand(tenStore, con);
                cm.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < Name_giatri.Length; i = i + 2)
                {
                    //Tạo ra các parameter
                    SqlParameter p = new SqlParameter(Name_giatri[i].ToString(), Name_giatri[i + 1]);
                    cm.Parameters.Add(p);

                }
                new SqlDataAdapter(cm).Fill(r);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return r;
        }
        /// <summary>
        /// Dùng để cập nhật dữ liệu trên DataTable lên DataBase
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tenbang"></param>
        public void UpdateDataBase(DataTable dt, string tenbang)
        {
            // b1: Xác định nguồn dữ liệu cần cập nhật
            SqlDataAdapter da;
            da = new SqlDataAdapter("Select * from " + tenbang, con);
            //b2. Khai báo đối tượng đồng bộ dữ liệu
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            int i = dt.Rows.Count;
            //b3 cập nhật dữ liệu
            da.Update(dt);
        }
        public static void DocTep(String tentep, out string Quyen, out string SN, out String DN, out String UN, out String PW)
        {
            StreamReader dr = new StreamReader(tentep);
            if (!dr.EndOfStream)
                Quyen = dr.ReadLine();
            else
                Quyen = "";

            if (!dr.EndOfStream)
                SN = dr.ReadLine();
            else
                SN = "";

            if (!dr.EndOfStream)
                DN = dr.ReadLine();
            else
                DN = "";

            if (!dr.EndOfStream)
                UN = dr.ReadLine();
            else
                UN = "";


            if (!dr.EndOfStream)
                PW = dr.ReadLine();
            else
                PW = "";
            dr.Close();

        }
        public static void GhiTep(String tentep, string Quyen, string SN, String DN, String UN, String PW)
        {
            StreamWriter dw = new StreamWriter(tentep);
            dw.WriteLine(Quyen);
            dw.WriteLine(SN);
            dw.WriteLine(DN);
            dw.WriteLine(UN);
            dw.WriteLine(PW);
            dw.Close();
        }
    }
}