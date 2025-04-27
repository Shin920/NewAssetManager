using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient; // 수정: MySQL 대신 MSSQL 사용
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAssetManager.DAC
{
    public class Address
    {
        public string ip_code { get; set; }
        public string ip_address { get; set; }
        public string ip_user { get; set; }
        public string ip_location { get; set; }
        public string ip_remark { get; set; }
    }

    class AddressDAC : IDisposable
    {
        SqlConnection conn; // 수정: MySqlConnection → SqlConnection

        public AddressDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public DataTable GetAddressInfo(string username, string address)
        {
            DataTable dt = new DataTable();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ip_code, ip_address, ip_user, ip_location, ip_remark FROM Address WHERE 1=1");

            if (!string.IsNullOrEmpty(username))
                sql.Append(" AND ip_user = @username");

            if (!string.IsNullOrEmpty(address))
                sql.Append(" AND ip_address = @address");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                if (!string.IsNullOrEmpty(username))
                    cmd.Parameters.AddWithValue("@username", username);
                if (!string.IsNullOrEmpty(address))
                    cmd.Parameters.AddWithValue("@address", address);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt); // 여기에 결과를 쫙 담아
                }
            }

            return dt;
        }
    }
}