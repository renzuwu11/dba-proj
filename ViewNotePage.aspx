<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewNotePage.aspx.cs" Inherits="DBAProject.ViewNotePage" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" rel="stylesheet">
    <title>#memow</title>
    <style>
        body {
            margin: 0;
            padding: 0;
            background-color: black;
            font-family: "Canva Sans", sans-serif;
        }

        /* Styles for app name */
        .app-name {
            position: absolute;
            top: 30px;
            left: 30px;
            font-size: 24px;
            font-weight: bold;
            color: white; 
            font-family: "Canva Sans", sans-serif; 
        }

        .filter-btn {
            background-color: #E2E2E2;
            color: #333; 
            border: none;
            width: 300px; 
            height: 7vh;
            text-align: left; 
            padding-left: 15px; 
            display: block;
            line-height: 34px; 
            text-decoration: none; 
            position: relative;
        }

        .filter-caret {
            position: absolute;
            right: 10px;
            top: 50%;
            transform: translateY(-50%);
        }

        .filter-btn:hover,
        .filter-btn:focus {
            background-color: white;
            color: #333; 
            outline: none;
        }

        .dropdown-menu {
            min-width: 300px; 
            right: 0;
        }

        .dropdown {
            position: absolute;
            top: 26px;
            right: 30px;
        }

        .container {
            flex-wrap: wrap;
            justify-content: space-between;
            padding: 10px;
        }

        .note-container {
            width: calc(100% - 10px);
            margin-bottom: 20px;
            padding: 15px;
            background-color: #E2E2E2;
            border-radius: 5px;
            overflow-y: auto;
            height: 60vh;
            display: flex;
            flex-direction: column;
        }

        .note-header {
            display: flex;
            justify-content: space-between; 
            align-items: center; 
            margin-bottom: 5px; 
        }

        .note-title {
            font-size: 20px;
            font-weight: bold;
            color: black; 
        }

        .note-date {
            font-size: 14px; 
            color: black; 
        }

        .note-subheader {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 5px;
        }

        .note-subtitle {
            font-size: 16px;
            color: black; 
        }

        .note-category {
            font-size: 14px; 
            color: black; 
        }

        .note-content {
            margin-top: 20px;
            margin-bottom: 10px;
            text-align: left;
        }

        .note-buttons {
            display: flex;
            justify-content: flex-end; 
            margin-top: auto; 
        }

        .edit-button,
        .delete-button {
            padding: 5px 10px;
            background-color: #333;
            color: #fff;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            margin-left: 5px; 
        }

        .edit-button:hover,
        .delete-button:hover {
            background-color: black;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <a href="LandingPage.aspx" class="app-name">#memow</a>
        
        <!-- Filter dropdown -->
        <div class="dropdown">
            <button class="btn btn-default filter-btn" type="button" id="filterDropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                Filter
                <span class="caret filter-caret"></span>
            </button>
            <ul class="dropdown-menu" aria-labelledby="filterDropdown">
                <li><a href="#"><span class="glyphicon glyphicon-arrow-up"></span> Date (Recent to Later)</a></li>
                <li><a href="#"><span class="glyphicon glyphicon-arrow-down"></span> Date (Later to Recent)</a></li>
            </ul>
        </div>
        <asp:Label ID="noNotesLabel" runat="server" Text="There are no notes to display." Visible="false"></asp:Label>
        <br /> <br /> <br /> <br /> 
        <div class="container">
            <asp:Repeater ID="NoteRepeater" runat="server">
                <ItemTemplate>
                    <div class="note-container">
                        <div class="note-header">
                            <span class="note-title"><%# Eval("NoteTitle") %></span>
                            <span class="note-date"><%# Eval("Note_CreatedDate", "{0:yyyy-MM-dd}") %></span>
                        </div>
                        <div class="note-subheader">
                            <span class="note-subtitle"><%# Eval("NoteSubtitle") %></span>
                            <span class="note-category"><%# Eval("CategoryName") %></span>
                        </div>
                        <div class="note-content">
                            <%# Eval("NoteContent") %>
                        </div>
                        <div class="note-buttons">
                            <asp:Button ID="EditButton" runat="server" Text="Edit" CssClass="edit-button" CommandName="Edit" />
                            <asp:Button ID="DeleteButton" runat="server" Text="Delete" CssClass="delete-button" CommandName="Delete" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>

    <!-- Bootstrap JavaScript and jQuery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</body>
</html>
