using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace DBAProject
{
    public partial class NewNotePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure that the user is logged in before accessing this page
            if (Session["UserID"] == null)
            {
                Response.Redirect("LoginSignupPage.aspx");
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the currently logged-in user's ID
                int UserID = GetCurrentUserID();

                // Check if the category is selected
                if (CategoryDropDown.SelectedIndex <= 0)
                {
                    Response.Write("<script>alert('Please select a category.');</script>");
                    return;
                }

                // Get other user input from the form
                int CategoryID = Convert.ToInt32(CategoryDropDown.SelectedValue);
                string NoteTitle = TitleTextBox.Text;
                string NoteSubtitle = SubtitleTextBox.Text;
                string NoteContent = TextBox.Text;
                int NoteWordCount = GetWordCount(NoteContent);
                int NoteCharacterCount = NoteContent.Length;

                // Call the method to create and save the new note
                if (CreateNewNote(UserID, CategoryID, NoteTitle, NoteSubtitle, NoteContent, NoteWordCount, NoteCharacterCount))
                {
                    // Redirect the user to the view note page after saving the note
                    Response.Redirect("ViewNotePage.aspx");
                }
                else
                {
                    // Handle the case where note creation fails
                    Response.Write("<script>alert('Failed to create the note.');</script>");
                }
            }
            catch (Exception)
            {
                // Log the exception or display an error message
                Response.Write("<script>alert('An error occurred while creating the note.');</script>");
            }
        }


        // Helper method to count the number of words in the note content
        private int GetWordCount(string text)
        {
            // Split the text into words and count them
            string[] words = text.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        // Method to create a new note and save it to the database using the stored procedure
        private bool CreateNewNote(int UserID, int CategoryID, string NoteTitle, string NoteSubtitle, string NoteContent, int NoteWordCount, int NoteCharacterCount)
        {
            try
            {
                // Define the connection string
                string connectionString = ConfigurationManager.ConnectionStrings["ProjectConnection"].ConnectionString;

                // Define the name of the stored procedure
                string procedureName = "SP_CreateNote";

                // Create and configure the SQL connection and command objects
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@NoteTitle", NoteTitle);
                    command.Parameters.AddWithValue("@NoteSubtitle", NoteSubtitle);
                    command.Parameters.AddWithValue("@NoteContent", NoteContent);
                    command.Parameters.AddWithValue("@NoteWordCount", NoteWordCount);
                    command.Parameters.AddWithValue("@NoteCharacterCount", NoteCharacterCount);

                    // Open the connection and execute the command
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true; // Note creation successful
                }
            }
            catch (Exception)
            {
                // Handle exceptions (e.g., log error, display error message)
                return false; // Note creation failed
            }
        }

        // Method to retrieve the current user's ID from session
        private int GetCurrentUserID()
        {
            // Retrieve user ID from session variable
            if (Session["UserID"] != null)
            {
                return Convert.ToInt32(Session["UserID"]);
            }
            else
            {
                // Handle case where user ID is not found
                throw new ApplicationException("User ID not found.");
            }
        }
    }
}
