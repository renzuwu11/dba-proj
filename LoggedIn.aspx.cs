using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBAProject
{
    public partial class LoggedIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void logoutButton_Click(object sender, EventArgs e)
        {
            // This method will be called when the LoginSignupButton is clicked
            Response.Redirect("~/LandingPage.aspx");
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