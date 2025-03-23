using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using StockManagement.DL;

namespace StockManagement.BL
{
    public class UserManager
    {
        public static string SignUp(string username, string email, string password, string roleName)
        {
            string roleQuery = "SELECT role_id FROM roles WHERE role_name = @roleName";
            var roleParameters = new[] { new MySqlParameter("@roleName", roleName) };
            object roleId = DataLayer.ExecuteScalar(roleQuery, roleParameters);

            if (roleId == null) return "Invalid role!";

            string query = "INSERT INTO users (username, email, password_hash, role_id) VALUES (@username, @email, @password, @roleId)";
            var parameters = new[]
            {
                new MySqlParameter("@username", username),
                new MySqlParameter("@email", email),
                new MySqlParameter("@password", password),
                new MySqlParameter("@roleId", roleId)
            };

            int result = DataLayer.ExecuteNonQuery(query, parameters);
            return result > 0 ? "Sign-up successful!" : "Sign-up failed.";
        }

        public static string Login(string username, string password)
        {
            string query = "SELECT password_hash, role_id, user_id FROM users WHERE username = @username";
            var parameters = new[] { new MySqlParameter("@username", username) };
            DataTable dt = DataLayer.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return "Username not found.";

            string storedPassword = dt.Rows[0]["password_hash"].ToString();
            int roleId = Convert.ToInt32(dt.Rows[0]["role_id"]);
            int userId = Convert.ToInt32(dt.Rows[0]["user_id"]);

            if (password == storedPassword)
            {
                string roleQuery = "SELECT role_name FROM roles WHERE role_id = @roleId";
                var roleParam = new[] { new MySqlParameter("@roleId", roleId) };
                string roleName = DataLayer.ExecuteScalar(roleQuery, roleParam).ToString();

                // Updated format: add an extra comma between role and userId
                return $"Login successful! Welcome {username}, Role: {roleName}, UserId: {userId}";
            }
            return "Invalid password.";
        }

    }
}
