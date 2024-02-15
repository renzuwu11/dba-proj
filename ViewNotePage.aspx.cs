using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

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
        protected void DeleteButton_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int noteID = Convert.ToInt32(e.CommandArgument);

                // Call the method to delete the note by its ID
                if (DeleteNoteByID(noteID))
                {
                    // Refresh the notes after successful deletion
                    RefreshNotes();
                }
            }
        }

        // Method to delete a note by its ID using a stored procedure
        private bool DeleteNoteByID(int noteID)
        {
            try
            {
                // Define the connection string
                string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnection"].ConnectionString;

                // Define the name of the stored procedure for deleting a note by its ID
                string procedureName = "SP_DeleteNoteByID";

                // Create and configure the SQL connection and command objects
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.AddWithValue("@NoteID", noteID);

                    // Open the connection and execute the command
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true; // Note deletion successful
                }
            }
            catch (Exception)
            {
                // Handle exceptions (e.g., log error, display error message)
                return false; // Note deletion failed
            }
        }


        // Method to refresh the notes after deletion
        private void RefreshNotes()
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
        }

        protected void NoteRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                // Redirect to the NewNotePage with the NoteID as a query parameter
                Response.Redirect("~/NewNotePage.aspx?NoteID=" + e.CommandArgument);
            }
        }

    }
}
