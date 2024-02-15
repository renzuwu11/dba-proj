using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBAProject
{
    public partial class LandingPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LogOutButton_Click(object sender, EventArgs e)
        {
            // Perform logout action, such as clearing session variables
            Session.Clear(); // Clear all session variables

            // Redirect to login page
            Response.Redirect("~/LoginSignupPage.aspx");
        }

        protected void ViewNoteButton_Click(object sender, EventArgs e)
        {
            // This method will be called when the ViewNotesButton is clicked
            Response.Redirect("~/ViewNotePage.aspx");
        }
        protected void NewNoteButton_Click(object sender, EventArgs e)
        {
            // This method will be called when the ViewNotesButton is clicked
            Response.Redirect("~/NewNotePage.aspx");
        }
    }
}
