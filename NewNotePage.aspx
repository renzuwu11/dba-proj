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
            width: 31.6%; /* Adjust as needed */
            height: 7.5vh; /* Adjust as needed */
            border-radius: 10px; /* Rounded corners */
            background-color: #E2E2E2; /* Gray background */
            margin-left: 3.9%;
            margin-right: 1%;
            margin-bottom: .5%;
            border: none;
            text-align: center;
        }

        .SubtitleSquare {
            width: 21%; /* Adjust as needed */
            height: 7.5vh; /* Adjust as needed */
            border-radius: 10px; /* Rounded corners */
            background-color: #E2E2E2; /* Gray background */
            margin-top: 1%;/* Spacing between squares */
            margin-right: 1%;
            margin-bottom: .5%;
            border: none;
            text-align: center;
        }

        .CategorySquare {
            width: 21%; /* Adjust as needed */
            height: 7.5vh; /* Adjust as needed */
            border-radius: 10px; /* Rounded corners */
            background-color: #E2E2E2; /* Gray background */
            margin: 100px 0px; /* Spacing between squares */
            margin-bottom: .5%;
            border: none;
            text-align: center;
            line-height: 50px; /* Center text vertically */
        }

        .DateSquare {
            position: relative; /* Ensure relative positioning for absolute positioning of icon */
            width: 14%; /* Adjust as needed */
            height: 7.5vh; /* Adjust as needed */
            border-radius: 10px; /* Rounded corners */
            background-color: #E2E2E2; /* Gray background */
            margin: 100px 15px; /* Spacing between squares */
            margin-bottom: .5%;
            border: none;
            text-align: center;
            line-height: 50px; /* Center text vertically */
        }

        .TextSquare {
            position: relative;
            width: 91.7%;
            height: 60vh;
            border-radius: 10px;
            background-color: #E2E2E2;
            margin-left: 3.9%;
            margin-top: .5%;
            border: none;
            padding: 20px; /* Adjust padding as needed */
            resize: none; /* Disable resizing of the textarea */
            overflow-y: auto; /* Add scrollbar if content exceeds height */
            font-size: 16px; /* Set font size */
            line-height: 1.5; /* Set line height */
            box-sizing: border-box; /* Include padding in width calculation */
        }

        .save-button {
            width: calc(9% - 20px); /* Set width to 50% of container minus some margin */
            height: 5vh;
            padding: 4px;
            margin-top: .5%;
            margin-left: 88.2%;
            border: none;
            border-radius: 10px;
            font-size: 16px;
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
            bottom: 18%;
            right: 14%;
            font-size: 12px;
        }
        .char-count {
            position: absolute;
            bottom: 18%;
            right: 7%;
            font-size: 12px;
        }

/*      .format-button {
            margin-left: 3.9%;
            background-color: transparent;
            color: #E2E2E2;
            border: none;
            margin-right: 5px;
            cursor: pointer;
        }

        .format-button:hover,
        .format-button:active {
            color: black;
        }*/
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
            <asp:TextBox ID="DateTextBox" runat="server" CssClass="DateSquare" TextMode="Date" style="text-align: center; padding-left: 30px; padding-right: 40px;"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="TextBox" runat="server" CssClass="TextSquare" TextMode="MultiLine" placeholder="Write here..." oninput="countWords(this)"></asp:TextBox>
            <div id="wordCount" class="word-count">Words: 0</div>
            <div id="charCount" class="char-count">Characters: 0</div>
        </div>
        <div>
       <%-- <asp:Button ID="BoldButton" runat="server" Text="B" CssClass="format-button" OnClientClick="makeBold(); return false;" />
            <asp:Button ID="ItalicButton" runat="server" Text="I" CssClass="format-button" OnClientClick="makeItalic(); return false;" />
            <asp:Button ID="UnderlineButton" runat="server" Text="U" CssClass="format-button" OnClientClick="makeUnderline(); return false;" /> --%>
            <asp:Button ID="SaveButton" runat="server" CssClass="save-button" Text="save"/>
        </div>
    </form>

    <!-- Characters and Word Count -->
    <script>
        function countWords(textbox) {
            var text = textbox.value.trim();
            var words = text.split(/\s+/).filter(function (word) {
                return word.length > 0;
            }).length;
            var characters = text.length;
            document.getElementById('wordCount').innerText = "Words: " + words;
            document.getElementById('charCount').innerText = "Characters: " + characters;
        }
    </script>

    
<%--    <script>
        function makeBold() {
            var textBox = document.getElementById('<%= TextBox.ClientID %>');
            var currentStyle = textBox.style.fontWeight;
            if (currentStyle === 'bold') {
                textBox.style.fontWeight = 'normal';
                document.getElementById('<%= BoldButton.ClientID %>').style.color = ''; // Reset button color
            } else {
                textBox.style.fontWeight = 'bold';
                document.getElementById('<%= BoldButton.ClientID %>').style.color = 'black'; // Set button color
            }
        }

        function makeItalic() {
            var textBox = document.getElementById('<%= TextBox.ClientID %>');
            var currentStyle = textBox.style.fontStyle;
            if (currentStyle === 'italic') {
                textBox.style.fontStyle = 'normal';
                document.getElementById('<%= ItalicButton.ClientID %>').style.color = ''; // Reset button color
            } else {
                textBox.style.fontStyle = 'italic';
                document.getElementById('<%= ItalicButton.ClientID %>').style.color = 'black'; // Set button color
            }
        }

        function makeUnderline() {
            var textBox = document.getElementById('<%= TextBox.ClientID %>');
            var currentStyle = textBox.style.textDecoration;
            if (currentStyle === 'underline') {
                textBox.style.textDecoration = 'none';
                document.getElementById('<%= UnderlineButton.ClientID %>').style.color = ''; // Reset button color
            } else {
                textBox.style.textDecoration = 'underline';
                document.getElementById('<%= UnderlineButton.ClientID %>').style.color = 'black'; // Set button color
            }
        }
    </script>--%>


</body>
</html>