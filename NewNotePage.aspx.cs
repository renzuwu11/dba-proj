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

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the currently logged-in user's ID
                int userID = GetCurrentUserID();

                // Check if user ID retrieval was successful
                if (userID != 0)
                {
                    // Get other user input from the form
                    int categoryID = Convert.ToInt32(CategoryDropDown.SelectedValue);
                    string noteTitle = TitleTextBox.Text;
                    string noteSubtitle = SubtitleTextBox.Text;
                    string noteContent = TextBox.Text;
                    int noteWordCount = GetWordCount(noteContent);
                    int noteCharacterCount = noteContent.Length;

                    // Call the method to create and save the new note
                    if (CreateNewNote(userID, categoryID, noteTitle, noteSubtitle, noteContent, noteWordCount, noteCharacterCount))
                    {
                        // Optionally, you can redirect the user to another page after saving the note
                        Response.Redirect("ViewNotePage.aspx");
                    }
                    else
                    {
                        // Handle the case where note creation fails
                        Response.Redirect("ViewNotePage.aspx");
                    }
                }
                else
                {
                    // Handle the case where user ID retrieval fails
                    Response.Redirect("LandingPage.aspx");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or display an error message
                Response.Redirect("LandingPage.aspx");
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
        private bool CreateNewNote(int userID, int categoryID, string noteTitle, string noteSubtitle, string noteContent, int noteWordCount, int noteCharacterCount)
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
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@CategoryID", categoryID);
                command.Parameters.AddWithValue("@NoteTitle", noteTitle);
                command.Parameters.AddWithValue("@NoteSubtitle", noteSubtitle);
                command.Parameters.AddWithValue("@NoteContent", noteContent);
                command.Parameters.AddWithValue("@NoteWordCount", noteWordCount);
                command.Parameters.AddWithValue("@NoteCharacterCount", noteCharacterCount);

                try
                {
                    // Open the connection and execute the command
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true; // Note creation successful
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., log error, display error message)
                    // You might also want to roll back any changes made to the database in case of an error
                    return false; // Note creation failed
                }
            }
        }

        // Method to retrieve the current user's ID
        private int GetCurrentUserID()
        {
            // Mock scenario: Retrieve user ID from session variable
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
