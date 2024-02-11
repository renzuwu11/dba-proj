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
            height: 100vh;
            background-color: black;
            display: flex;
            justify-content: center;
            align-items: center;
            position: relative; 
        }

        .app-name {
            position: absolute;
            top: 26px;
            left: 30px;
            font-size: 24px;
            font-weight: bold;
            color: white;
            font-family: "Canva Sans", sans-serif;
        }

        .search-bar {
            position: absolute;
            top: 30px;
            right: 30px;
            width: calc(20% - 60px); 
            padding: 6px;
            margin-bottom: 10px;
            border: none;
            border-radius: 10px;
            font-size: 16px;
        }
        .search-icon {
            position: absolute;
            top: 38px; 
            right: 320px; 
            color: white;
            font-size: 20px;
            pointer-events: none; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="app-name">#memow</div>
        <asp:TextBox runat="server" CssClass="search-bar" placeholder="search" />
            <span class="glyphicon glyphicon-search search-icon"></span>
    </form>
</body>
</html>
