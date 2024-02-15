using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DBAProject
{
    public partial class ViewNotePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is logged in
                if (Session["username"] != null)
                {
                    string username = Session["username"].ToString();

                    // Get the user ID for the logged-in user
                    int userID = GetUserIDByUsername(username);

                    // Call the stored procedure to get notes for the logged-in user
                    DataTable dt = GetNotesByUserID(userID);

                    // Bind the retrieved notes to the Repeater control
                    NoteRepeater.DataSource = dt;
                    NoteRepeater.DataBind();

                    // Show a message if there are no notes
                    if (dt.Rows.Count == 0)
                    {
                        noNotesLabel.Visible = true;
                    }
                    else
                    {
                        noNotesLabel.Visible = false;
                    }
                }
                else
                {
                    // Redirect the user to the login page if not logged in
                    Response.Redirect("~/LoginSignupPage.aspx");
                }
            }
        }

        // Method to get the user ID by username
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

        // Method to call the stored procedure and retrieve notes for the specified user ID
        private DataTable GetNotesByUserID(int userID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetNotesByUserID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userID);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
