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
            font-family: "Canva Sans", sans-serif;
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

        .filter-btn {
            background-color: #E2E2E2;
            color: #333; /* Text color */
            border: none;
            width: 300px; /* Set width of the button */
            text-align: left; /* Align text to the left */
            padding-left: 15px; /* Add padding to the left side */
            display: block;
            line-height: 34px; /* Center the text vertically */
            text-decoration: none; /* Remove underline */
            position: relative;
        }

        .filter-caret {
            position: absolute;
            right: 10px; /* Adjust the position of the caret */
            top: 50%;
            transform: translateY(-50%);
        }

        .filter-btn:hover,
        .filter-btn:focus {
            background-color: white; /* Change background color on hover */
            color: #333; /* Text color */
            outline: none;
        }

        /* Adjust the position and width of the dropdown */
        .dropdown-menu {
            min-width: 300px; /* Match the width of the button */
            right: 0; /* Align the dropdown with the button */
        }

        /* Adjust the position of the dropdown */
        .dropdown {
            position: absolute;
            top: 26px;
            right: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="app-name">#memow</div>
        
        <!-- Filter dropdown -->
        <div class="dropdown">
            <button class="btn btn-default filter-btn" type="button" id="filterDropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                Filter
                <span class="caret filter-caret"></span>
            </button>
            <ul class="dropdown-menu" aria-labelledby="filterDropdown">
                <li><a href="#"><span class="glyphicon glyphicon-arrow-up"></span> Date (Recent to Later)</a></li>
                <li><a href="#"><span class="glyphicon glyphicon-arrow-down"></span> Date (Later to Recent)</a></li>
                <li><a href="#"><span class="glyphicon glyphicon-bookmark"></span> Favorites</a></li>
            </ul>
        </div>
    </form>

    <!-- Bootstrap JavaScript and jQuery -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</body>
</html>
