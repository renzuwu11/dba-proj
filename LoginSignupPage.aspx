<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginSignupPage.aspx.cs" Inherits="DBAProject.LoginSignupPage" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>#memow</title>
    <link rel="stylesheet" href="styles.css">
    <style> 
    body {
        margin: 0;
        padding: 0;
        height: 100vh;
        background-color: black;
        display: flex;
        justify-content: center;
        align-items: center; 
    }
    .error-message {
        color: red;
    }

    </style>

</head>
<body>
    <form id="form1" class="login-form" runat="server">
    <asp:Label ID="errorMessage" runat="server" CssClass="error-message" Visible="false" ForeColor="Red"></asp:Label>
        <div class="login-container">
            <!-- Content for the square -->
            <h1 class="login-header">#memow</h1>
            <div class="login-input">
                <label for="username">username</label><br />
                <asp:TextBox ID="username" runat="server" CssClass="login-input" style="width: 90%; height: 20px; background-color: #E2E2E2; border: none; border-radius: 10px;" />
            </div>
            <div class="login-input">
                <label for="password">password</label><br />
                <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="login-input" style="margin-bottom: 30px; width: 90%; height: 20px; background-color: #E2E2E2; border: none; border-radius: 10px;" />
            </div>
            <div style="display: flex; justify-content: space-between;">
                <asp:Button ID="loginButton" runat="server" CssClass="login-button" Text="log in" OnClick="loginButton_Click" />
                <asp:Button ID="signupButton" runat="server" CssClass="login-button" Text="sign up" OnClick="SignUpButton_Click" />

            </div>
        </div>
    </form>
</body>
</html>
