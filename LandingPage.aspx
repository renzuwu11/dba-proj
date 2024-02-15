<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="DBAProject.LandingPage1" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>#memow</title>
    <link rel="stylesheet" href="styles.css">
    <style>

        /* Styles for login/signup button */
    .logout-button {
        position: absolute;
        top: 30px;
        right: 30px;
        padding: 10px 20px;
        font-size: 14px;
        font-family: "Canva Sans", sans-serif; /* Use Canva Sans font */
        border: none;
        border-radius: 20px;
        background-color: #545454; /* Initial background color */
        color: white;
        cursor: pointer;
    }

    /* Hover styles for login/signup button */
    .logout-button:hover {
        background-color: black; /* Hover background color */
    }

    </style>
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
        <div id="logoutContainer" runat="server">
            <asp:Button ID="LogOutButton" runat="server" CssClass="logout-button" Text="log out" OnClick="LogOutButton_Click" />
        </div>
        <div class="app-name">#memow</div>

    </form>
</body>
</html>
