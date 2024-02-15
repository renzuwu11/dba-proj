using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace DBAProject
{
    public partial class LoginSignupPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["ProjectConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            string username = this.Username.Text;
            string passwordHash = this.PasswordHash.Text;

            // Call the stored procedure to validate user credentials
            int isValid = ValidateUser(username, passwordHash);

            if (isValid == 1)
            {
                // Retrieve the user ID after successful login
                int userID = GetUserIDByUsername(username);

                // Store the username and userID in session variables
                Session["Username"] = username;
                Session["UserID"] = userID;

                // Display alert message using JavaScript
                string script = "alert('Logged in successfully!');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

                // Redirect to home page after a delay to allow the user to see the alert
                Response.AddHeader("REFRESH", "0;URL=LandingPage.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid username or password!');</script>");
                errorMessage.Visible = true;
            }
        }


        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            string username = this.Username.Text;
            string passwordHash = this.PasswordHash.Text;

            // Call the stored procedure to create a new user
            string message = CreateUser(username, passwordHash);

            // Check the message returned by the stored procedure
            if (message.Contains("successfully"))
            {
                // User creation was successful
                Response.Write("<script>alert('" + message + "');</script>");
            }
            else
            {
                // User creation failed (username already exists or other error)
                Response.Write("<script>alert('Failed to create user: " + message + "');</script>");
                errorMessage.Visible = true;
            }
        }


        // Function to call the stored procedure for user authentication
        private int ValidateUser(string username, string passwordHash)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SP_ValidateUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    int isValid = Convert.ToInt32(cmd.ExecuteScalar());
                    return isValid;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return 0;
            }
        }

        private int GetUserIDByUsername(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT UserID FROM Users WHERE Username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result == null ? 0 : Convert.ToInt32(result);
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