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
    public class ReviewManager
    {
        public static string AddReview(int userId, string review)
        {
            string query = "INSERT INTO reviews (user_id, message) VALUES (@userId, @review)";
            var parameters = new[]
            {
                new MySqlParameter("@userId", userId),
                new MySqlParameter("@review", review)
            };

            int result = DataLayer.ExecuteNonQuery(query, parameters);
            return result > 0 ? "Review added successfully!" : "Failed to add review.";
        }

        public static DataTable ViewReviews()
        {
            string query =
              "SELECT r.review_id, r.user_id, u.username, r.message, r.submitted_at " +
              "FROM reviews r JOIN users u ON r.user_id = u.user_id " +
              "ORDER BY r.submitted_at DESC";
            return DataLayer.ExecuteQuery(query);
        }
    }
}
