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
                // Check if the user is logged in (you might have your own authentication logic here)
                int userID = GetLoggedInUserID(); // You need to implement this method

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
            }
        }

        // Method to get the ID of the logged-in user (you need to implement your own authentication logic)
        private int GetLoggedInUserID()
        {
            // This is just a placeholder. You should replace this with your actual authentication logic.
            // For example, if you are using ASP.NET Identity, you might use something like:
            // return User.Identity.GetUserId<int>();

            // For now, let's assume user ID 1 is logged in.
            return 1;
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
