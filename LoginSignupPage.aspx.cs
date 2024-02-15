using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace DBAProject
{
    public partial class LoginSignupPage : System.Web.UI.Page
    {
        protected void loginButton_Click(object sender, EventArgs e)
        {
            string Username = this.Username.Text;
            string PasswordHash = this.PasswordHash.Text;

            // Call the stored procedure to validate user credentials
            int isValid = ValidateUser(Username, PasswordHash);

            if (isValid == 1)
            {
                // User authenticated successfully, redirect to home page
                Response.Redirect("LandingPage.aspx");
            }
            else
            {
                errorMessage.Text = "Invalid username or password.";
                errorMessage.Visible = true;
            }
        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            string Username = this.Username.Text;
            string PasswordHash = this.PasswordHash.Text;

            // Call the stored procedure to create a new user
            string message = CreateUser(Username, PasswordHash);

            // Display message to user
            errorMessage.Text = message;
            errorMessage.Visible = true;
        }

        // Function to call the stored procedure for user authentication
        private int ValidateUser(string Username, string PasswordHash)
        {
            // Retrieve connection string from configuration file
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnection"].ConnectionString;

            // Use retrieved connection string to create SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_ValidateUser", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@PasswordHash", PasswordHash); // Note: Password hashing should be used for security
                    connection.Open();
                    int isValid = Convert.ToInt32(command.ExecuteScalar());
                    return isValid;
                }
            }
        }

        // Function to call the stored procedure for user registration
        public string CreateUser(string Username, string PasswordHash)
        {
            // Retrieve connection string from configuration file
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnection"].ConnectionString;

            // Use retrieved connection string to create SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_CreateUser", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@PasswordHash", PasswordHash);

                    connection.Open();
                    string message = command.ExecuteScalar().ToString();
                    return message;
                }
            }
        }
    }
}