using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace QLNhanSu_He2024
{
    public static class Data_Provider
    {
        private static SqlConnection cnn;
        private static SqlDataAdapter da;
        private static SqlCommand cmd;

        //Kết nối đến CSDL
        public static void moKetNoi()
        {
            cnn = new SqlConnection();
            cnn.ConnectionString = ConfigurationManager.ConnectionStrings["QLNS"].ConnectionString.ToString();
            cnn.Open();
        }
        //Đóng kết nối
        public static void dongKetNoi()
        {
            cnn.Close();
        }

        //Lấy dữ liệu từ Database đổ lên DataTable
        public static DataTable getTable(string sql)
        {
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(sql, cnn);
            da.Fill(dt);
            return dt;
        }

        //Cập nhật dữ liệu
        public static void updateData(string sql, object[] value =null,string[]name =null )
        {
            cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.Clear();
            if (value!=null)
            {
                for (int i = 0; i < value.Length; i++)
                    cmd.Parameters.AddWithValue(name[i], value[i]);
            }    
            cmd.ExecuteNonQuery();//Thực thi câu lệnh Insert, Delete, Update
            cmd.Dispose();
        }

        //Kiểm tra khóa chính có trùng
        public static int checkData(string sql)
        {
            int i = 0;
            cmd = new SqlCommand(sql, cnn);
             i = (int)cmd.ExecuteScalar();
            cmd.Dispose();
            return i;
        }

    }
}
