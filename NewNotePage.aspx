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
            position: relative; 
            font-family: "Canva Sans", sans-serif;
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
        /* Custom style for the square */
        .TitleSquare {
            width: 500px; /* Adjust as needed */
            height: 50px; /* Adjust as needed */
            border-radius: 10px; /* Rounded corners */
            background-color: #E2E2E2; /* Gray background */
            margin-top: 100px;/* Spacing between squares */
            margin-left: 60px;
            margin-right: 15px;
            margin-bottom: 0px;
            border: none;
            text-align: center;
        }

        .SubtitleSquare {
            width: 350px; /* Adjust as needed */
            height: 50px; /* Adjust as needed */
            border-radius: 10px; /* Rounded corners */
            background-color: #E2E2E2; /* Gray background */
            margin-top: 100px;/* Spacing between squares */
            margin-right: 15px;
            margin-bottom: 10px;
            border: none;
            text-align: center;
        }

        .CategorySquare {
            position: relative; /* Ensure relative positioning for absolute positioning of caret */
            width: 350px; /* Adjust as needed */
            height: 50px; /* Adjust as needed */
            border-radius: 10px; /* Rounded corners */
            background-color: #E2E2E2; /* Gray background */
            margin: 100px 0px; /* Spacing between squares */
            margin-bottom: 10px;
            border: none;
            text-align: center;
            line-height: 50px; /* Center text vertically */
        }

        .DateSquare {
            position: relative; /* Ensure relative positioning for absolute positioning of icon */
            width: 300px; /* Adjust as needed */
            height: 50px; /* Adjust as needed */
            border-radius: 10px; /* Rounded corners */
            background-color: #E2E2E2; /* Gray background */
            margin: 100px 15px; /* Spacing between squares */
            margin-bottom: 10px;
            border: none;
            text-align: center;
            line-height: 50px; /* Center text vertically */
        }

        .TextSquare {
            position: relative;
            width: 1558px;
            height: 500px;
            border-radius: 10px;
            background-color: #E2E2E2;
            margin-left: 60px;
            margin-top: 20px;
            border: none;
            padding: 20px; /* Adjust padding as needed */
            resize: none; /* Disable resizing of the textarea */
            overflow-y: auto; /* Add scrollbar if content exceeds height */
            font-size: 16px; /* Set font size */
            line-height: 1.5; /* Set line height */
            box-sizing: border-box; /* Include padding in width calculation */
        }

        .save-button {
            width: calc(10% - 20px); /* Set width to 50% of container minus some margin */
            padding: 10px;
            margin-top: 30px;
            margin-left: 87.3%;
            border: none;
            border-radius: 10px;
            font-size: 18px;
            cursor: pointer;
            background-color: #E2E2E2; /* Set initial background color */
            color: black; /* Set text color */
        }

        /* Change button color on hover */
        .save-button:hover {
            background-color: black; /* Hover background color */
            color: white; /* Hover text color */
        }

        .word-count {
            position: absolute;
            bottom: 150px;
            right: 90px;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="app-name">#memow</div>
        <div>
            <!-- Square for Title -->
            <asp:TextBox ID="TitleTextBox" runat="server" CssClass="TitleSquare" placeholder="Title"></asp:TextBox>
            <!-- Square for Title -->
            <asp:TextBox ID="SubtitleTextBox" runat="server" CssClass="SubtitleSquare" placeholder="Subtitle"></asp:TextBox>
            <!-- Square for Category -->
            <asp:DropDownList ID="CategoryDropDown" runat="server" CssClass="CategorySquare">
                <asp:ListItem Text="Select Category" Value=""></asp:ListItem>
                <asp:ListItem Text="School" Value="School"></asp:ListItem>
                <asp:ListItem Text="Work" Value="Work"></asp:ListItem>
                <asp:ListItem Text="Daily" Value="Daily"></asp:ListItem>
            </asp:DropDownList >
            <!-- Square for Date -->
        <asp:TextBox ID="DateTextBox" runat="server" CssClass="DateSquare" TextMode="Date" style="text-align: center; padding-left: 50px; padding-right: 70px;"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="TextBox" runat="server" CssClass="TextSquare" TextMode="MultiLine" placeholder="Write here..." oninput="countWords(this)"></asp:TextBox>
            <div id="wordCount" class="word-count">Words: 0</div>
        </div>
        <div>
            <asp:Button ID="SaveButton" runat="server" CssClass="save-button" Text="save"/>
        </div>
    </form>

    <script>
        function countWords(textbox) {
            var words = textbox.value.trim().split(/\s+/).filter(function (word) {
                return word.length > 0;
            }).length;
            document.getElementById('wordCount').innerText = "Words: " + words;
        }
    </script>
</body>
</html>