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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            string enteredUsername = username.Text;
            string enteredPassword = password.Text;

            // Check if the username and password are correct by querying the database
            if (ValidateUser(enteredUsername, enteredPassword))
            {
                // Redirect the user to the landing page upon successful login
                Response.Redirect("LoggedIn.aspx");
            }
            else
            {
                // Display an error message if the credentials are incorrect
                // You can implement this as needed, such as displaying a message on the page
            }
        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            string connectionString = "DbConnection";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("CreateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", username.Text);
                        command.Parameters.AddWithValue("@PasswordHash", password.Text); 

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // User successfully created
                            errorMessage.Text = "Sign up successful!";
                            errorMessage.Visible = true;

                            // Redirect to the landing page
                            Response.Redirect("LandingPage.aspx");
                        }
                        else
                        {
                            // No rows affected, sign up failed
                            errorMessage.Text = "Failed to sign up. Please try again.";
                            errorMessage.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                errorMessage.Text = "An error occurred while signing up. Please try again later.";
                errorMessage.Visible = true;
                // Log the exception details for debugging purposes
                Console.WriteLine(ex.ToString());
            }
        }

        private bool ValidateUser(string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString; // Retrieve connection string from web.config
            bool isValid = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("ValidateUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@PasswordHash", password);

                    connection.Open();
                    isValid = Convert.ToBoolean(command.ExecuteScalar());
                }
            }

            return isValid;
        }

    }
}
