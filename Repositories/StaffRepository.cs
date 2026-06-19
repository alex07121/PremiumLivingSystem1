using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using PremiumLivingSystem.Models;

namespace PremiumLivingSystem.Repositories
{
    /// <summary>
    /// Staff Repository implementation (connect MySQL)
    /// </summary>
    public class StaffRepository : IStaffRepository
    {
        private readonly string _connectionString;

        public StaffRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["PLFCDB"]?.ConnectionString
                ?? throw new InvalidOperationException("Connection string 'PLFCDB' not found.");
        }

        public Staff GetByStaffId(string staffId)
        {
            string sql = @"
                    SELECT StaffID, StaffName, Job_ID, PasswordHash, Phone, Email, HireDate 
                    FROM staff 
                    WHERE StaffID = @staffId";

            using (var conn = new MySqlConnection(_connectionString))
            {
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@staffId", staffId);
                conn.Open();

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var staff = new Staff
                    {
                        StaffID = reader.GetString("StaffID"),
                        StaffName = reader.GetString("StaffName"),
                        JobID = reader.GetString("Job_ID"),
                        PasswordHash = reader.GetString("PasswordHash"),
                        Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone"),
                        Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email"),
                        HireDate = reader.GetDateTime("HireDate")
                    };
                    reader.Close();
                    return staff;
                }
                reader.Close();
            }

            return null; // Cannot find user with the staffId
        }

        public List<Staff> GetAllStaff()
        {
            var staffList = new List<Staff>();

            string sql = @"
                    SELECT StaffID, StaffName, Job_ID, Phone, Email, HireDate 
                    FROM staff 
                    ORDER BY StaffID";

            using (var conn = new MySqlConnection(_connectionString))
            {
                var cmd = new MySqlCommand(sql, conn);
                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    staffList.Add(new Staff
                    {
                        StaffID = reader.GetString("StaffID"),
                        StaffName = reader.GetString("StaffName"),
                        JobID = reader.GetString("Job_ID"),
                        Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString("Phone"),
                        Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email"),
                        HireDate = reader.GetDateTime("HireDate")
                    });
                }
                reader.Close();
            }

            return staffList;
        }

        public bool AddStaff(Staff staff)
        {
            string sql = @"
                    INSERT INTO staff (StaffID, StaffName, Job_ID, PasswordHash, Phone, Email, HireDate)
                    VALUES (@staffId, @staffName, @jobId, @passwordHash, @phone, @email, @hireDate)";

            using (var conn = new MySqlConnection(_connectionString))
            {
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@staffId", staff.StaffID);
                cmd.Parameters.AddWithValue("@staffName", staff.StaffName);
                cmd.Parameters.AddWithValue("@jobId", staff.JobID);
                cmd.Parameters.AddWithValue("@passwordHash", staff.PasswordHash);
                cmd.Parameters.AddWithValue("@phone", (object)staff.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@email", (object)staff.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@hireDate", staff.HireDate);
                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool UpdateStaff(Staff staff)
        {
            string sql = @"
                    UPDATE staff 
                    SET StaffName = @staffName, 
                        Job_ID = @jobId, 
                        Phone = @phone, 
                        Email = @email
                    WHERE StaffID = @staffId";

            using (var conn = new MySqlConnection(_connectionString))
            {
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@staffName", staff.StaffName);
                cmd.Parameters.AddWithValue("@jobId", staff.JobID);
                cmd.Parameters.AddWithValue("@phone", (object)staff.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@email", (object)staff.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@staffId", staff.StaffID);
                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool DeleteStaff(string staffId)
        {
            string sql = "DELETE FROM staff WHERE StaffID = @staffId";

            using (var conn = new MySqlConnection(_connectionString))
            {
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@staffId", staffId);
                conn.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}