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
        public string ip_address { get; set; }
        public string ip_purpose { get; set; }
        public string ip_dept { get; set; }
        public string ip_user { get; set; }
        public string ip_location { get; set; }
        public string ip_remark { get; set; }
        public string ip_date { get; set; }
        public string ip_external { get; set; }
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
            sql.Append("SELECT IP, 용도, 소속, 사용자명, 설치위치, 비고, 할당일자, 외부사용 FROM CPT_IP WHERE 1=1");

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
            sql.Append("SELECT IP, 용도, 소속, 사용자명, 설치위치, 비고, 할당일자, 외부사용 FROM CPT_IP WHERE 1=1");

            if (!string.IsNullOrEmpty(value.ip_user))
                sql.Append(" AND 사용자명 = @username");

            if (!string.IsNullOrEmpty(value.ip_address))
                sql.Append(" AND IP = @address");

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
                string sql = @"UPDATE CPT_IP SET 용도=@purpose, 소속=@dept, 사용자명=@user, 설치위치=@location, 
                            비고=@remark, 할당일자=@date, 외부사용=@external WHERE IP=@ip_Address";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@purpose", value.ip_purpose);
                    cmd.Parameters.AddWithValue("@dept", value.ip_dept);
                    cmd.Parameters.AddWithValue("@user", value.ip_user);
                    cmd.Parameters.AddWithValue("@location", value.ip_location);
                    cmd.Parameters.AddWithValue("@remark", value.ip_remark);
                    cmd.Parameters.AddWithValue("@date", value.ip_date);
                    cmd.Parameters.AddWithValue("@external", value.ip_external);
                    cmd.Parameters.AddWithValue("@ip_address", value.ip_address);
                   

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // 예외를 상위로 던지거나, 로깅
                throw new Exception("Update 실패: " + ex.Message);
            }
        }

        public int Delete(Address value)
        {
            try
            {
                string sql = @"DELETE FROM CPT_IP WHERE IP = @ip_address";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ip_address", value.ip_address);

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Delete 실패: " + ex.Message);
            }
        }


        //등록부는 New Form 사용
        public int Insert(Address value)
        {
            try
            {
                string sql = @"INSERT INTO CPT_IP (IP, 용도, 소속, 사용자명, 설치위치, 비고, 할당일자, 외부사용)
                       VALUES (@ip_address, @ip_purpose, @ip_dept, @ip_user, @ip_location, @ip_remark, @ip_date, @ip_external)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ip_address", value.ip_address);
                    cmd.Parameters.AddWithValue("@ip_purpose", value.ip_purpose);
                    cmd.Parameters.AddWithValue("@ip_dept", value.ip_dept);
                    cmd.Parameters.AddWithValue("@ip_user", value.ip_user);
                    cmd.Parameters.AddWithValue("@ip_location", value.ip_location);
                    cmd.Parameters.AddWithValue("@ip_remark", value.ip_remark);
                    cmd.Parameters.AddWithValue("@ip_date", value.ip_date);
                    cmd.Parameters.AddWithValue("@ip_external", value.ip_external);

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Insert 실패: " + ex.Message);
            }
        }
    }
}