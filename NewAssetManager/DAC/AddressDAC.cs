using MySql.Data.MySqlClient;
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

        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ip_code, ip_address, ip_user, ip_location, ip_remark FROM Address WHERE 1=1");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable GetAddressInfo(Address value)
        {
            DataTable dt = new DataTable();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ip_code, ip_address, ip_user, ip_location, ip_remark FROM Address WHERE 1=1");

            if (!string.IsNullOrEmpty(value.ip_user))
                sql.Append(" AND ip_user = @username");

            if (!string.IsNullOrEmpty(value.ip_address))
                sql.Append(" AND ip_address = @address");

            using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
            {
                if (!string.IsNullOrEmpty(value.ip_user))
                    cmd.Parameters.AddWithValue("@username", value.ip_user);
                if (!string.IsNullOrEmpty(value.ip_address))
                    cmd.Parameters.AddWithValue("@address", value.ip_address);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt); // 결과 담아주기
                }
            }

            return dt;
        }

        public int Update(Address value)
        {
            try
            {
                string sql = @"UPDATE Address SET ip_user=@ip_user, ip_address=@ip_address WHERE ip_code=@ip_code";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ip_user", value.ip_user);
                    cmd.Parameters.AddWithValue("@ip_address", value.ip_address);
                    cmd.Parameters.AddWithValue("@ip_code", value.ip_code);

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // 예외를 상위로 던지거나, 로깅
                throw new Exception("Update 실패: " + ex.Message);
            }
        }

        public int Delete(string ip_code)
        {
            try
            {
                string sql = @"DELETE FROM Address WHERE ip_code = @ip_code";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ip_code", ip_code);

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Delete 실패: " + ex.Message);
            }
        }


        //등록부는 Primary Key인 ip_code 항목의 입력까지 필요하므로 따로 작성하지 않음
        //public int Insert(Address value)
        //{
        //    try
        //    {
        //        string sql = @"INSERT INTO Address (ip_user, ip_address)
        //               VALUES (@ip_user, @ip_address)";
        //        using (SqlCommand cmd = new SqlCommand(sql, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@ip_user", value.ip_user);
        //            cmd.Parameters.AddWithValue("@ip_address", value.ip_address);                   

        //            return cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Insert 실패: " + ex.Message);
        //    }
        //}
    }
}