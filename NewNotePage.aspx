<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewNotePage.aspx.cs" Inherits="DBAProject.NewNotePage" %>

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
            background-color: white;
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
            color: black;
            font-family: "Canva Sans", sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="app-name">#memow</div>
    </form>
</body>
</html>

