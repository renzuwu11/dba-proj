using System;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;

namespace DBAProject
{
    public partial class LandingPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    string username = Session["username"].ToString();
                }
                else
                {
                    Response.Redirect("~/LoginSignupPage.aspx");
                }
            }
        }


        protected void LogOutButton_Click(object sender, EventArgs e)
        {
            // Clear all session variables
            Session.Clear();

            // Redirect to the login page
            Response.Redirect("~/LoginSignupPage.aspx");
        }

        protected void ViewNoteButton_Click(object sender, EventArgs e)
        {
            // Redirect to the ViewNotePage
            Response.Redirect("~/ViewNotePage.aspx");
        }

        protected void NewNoteButton_Click(object sender, EventArgs e)
        {
            // Redirect to the NewNotePage
            Response.Redirect("~/NewNotePage.aspx");
        }
    }
}
