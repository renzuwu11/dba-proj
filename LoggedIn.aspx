<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggedIn.aspx.cs" Inherits="DBAProject.LoggedIn" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>#memow</title>
    <link rel="stylesheet" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="button-container">
            <div class="button-column" style="background-color: black;">
                <asp:Button ID="ViewNoteButton" runat="server" CssClass="button left-button" Text="#ViewNote" OnClick="ViewNoteButton_Click" />
            </div>
            <div class="button-column" style="background-color: white;">
                <asp:Button ID="NewNoteButton" runat="server" CssClass="button right-button" Text="#NewNote" OnClick="NewNoteButton_Click" />
            </div>
        </div>

        <!-- Login/Signup button -->
        <div id="loginSignupContainer" runat="server" class="login-signup-container">
            <asp:Button ID="LogOutButton" runat="server" CssClass="login-signup-button" Text="log out" OnClick="logoutButton_Click" />
        </div>
        <div class="app-name">#memow</div>

    </form>
</body>
</html>