<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Homestead_Project.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report</title>
        <link href="CSS_SHEET.css" type="text/css" rel="stylesheet" />
     <link href="StyleSheet1.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="JS_FILE.js"></script>
</head>
<body style="background: url(leaf-background2.png) fixed;">
          <nav class="sidenav" tabindex="0">
        <header class="pic">
            <img src="logo.PNG" />
                <h3>Welcome</h3>
        </header>
        <ul class="mainmenu">
           <li>
                <a href="HOME_PAGE.aspx">Home</a>
           </li>
            <li><a href="#">Children Details</a>
               <ul class="submenu">
                    <li><a href="View_Child_Details.aspx">View Children Details</a></li>
                    <li><a href="Add_Child_Details.aspx">Add New Child</a></li>
                    <li><a href="Update_Child_Details.aspx">Update Child Details</a></li>
               </ul>
            </li>
            <li> <a href="#">Attendance</a>
                  <ul class="submenu">
                    <li><a href="Daily_Attendance_Register.aspx">Record Daily Attendance</a></li>
                    <li><a href="AttendanceRecord_Per_Child.aspx">View Attendance Sheet Per child</a></li>
                    <li><a href="Monthly_Attendance_Report.aspx">View Montly Attendance Sheet</a></li>
                </ul>
            </li>
            <li><a href="Activities.aspx">Activities</a>
                  <ul class="submenu">
                    <li><a href="Activity_Attendance_Register.aspx">View Activity Attendance Report</a></li>
                </ul>
            </li>
            <li><a href="Planner.aspx">Planner</a>
                <ul class="submenu">
                    <li><a href="testing.aspx">View Planner</a></li>
                    <li><a href="testing.aspx">View Birthdays</a></li>
                    <li><a href="testing.aspx">View Notifications</a></li>
                </ul>
            </li>
            <li>
                <a href="Point_System.aspx">Points</a>
           </li>
            <li>
                <a href="Register_New_User.aspx">Register New User</a>
            </li>
            <li>
                <a href="Report.aspx">Report</a>
            </li>
            <li>
                <a href="LOG_IN.aspx">Log Out</a>
            </li>
        </ul>
    </nav>
    <div id="main">
        <div class="hero-image">
            <h1 class="heading">View Details Below</h1>   
        </div>
        <form id="form1" runat="server">
            <div class="report-box">
                 <div class="container">
                <h2>Monthly Report on each Project</h2>
   
                     <div class="report">
                        
                              <div class="left">
                            <asp:Label runat="server" text="Facilities" CssClass="labels"/>
                            <asp:dropdownlist id="cbFalicities" runat="server" CssClass="textInputs" OnSelectedIndexChanged="cbFalicities_SelectedIndexChanged" AutoPostBack="true"></asp:dropdownlist>
                    </div>
               
                        <div class="middle">
                            <asp:Label runat="server"  CssClass="labels" Text="Choose The Month you want to view the report for:"/>
					<asp:DropDownList ID="MonthCombo" runat="server" CssClass="textInputs" OnSelectedIndexChanged="MonthCombo_SelectedIndexChanged" AutoPostBack="true">
                    	<asp:ListItem Text="January"/>
						<asp:ListItem Text="February" />
						<asp:ListItem Text="March" />
                        <asp:ListItem Text="April" />
                        <asp:ListItem Text="May" />
                        <asp:ListItem Text="June" />
                        <asp:ListItem Text="July" />
                        <asp:ListItem Text="August" />
                        <asp:ListItem Text="September" />
                        <asp:ListItem Text="October" />
                        <asp:ListItem Text="November" />
                        <asp:ListItem Text="December" />
					    <asp:ListItem></asp:ListItem>
					</asp:DropDownList>
                        </div>
                         <div class="right">
                             <asp:Button runat="server" Text ="SEARCH" ID="bntSearch" OnClick="btnSearch" CssClass="buttons" />
                         </div>
                         
   
                         
                          <asp:Label runat="server" Text="Number of Activities Performed this month:" CssClass="left"/>
                         <asp:Label runat="server"  ID="txtNumOfActivities" CssClass="right"/>
                         <asp:Label runat="server" Text="Number of Children Enroled this month" CssClass="left"/>
                         <asp:Label runat="server"  ID="txtNumOfEnrolment" CssClass="right"/>
                         <asp:Label runat="server" Text="Number of children Dismissed" CssClass="left"/>
                         <asp:Label runat="server"  ID="txtNumOfDismissed" CssClass="right"/>
                         <asp:Label runat="server" Text="Number of Home Visits This Month:" CssClass="left"/>
                         <asp:Label runat="server"  ID="txtNumOfHV" CssClass="right"/>
                         
                         <asp:Label runat="server" Text="Number of Birthdays This Month:" CssClass="left"/>
                         <asp:Label runat="server"  ID="txtNumOfBirthdays" CssClass="right"/>
                         <asp:Label runat="server" Text="Number of Court Visits This Month:" CssClass="left"/>
                         <asp:Label runat="server" ID="txtCourtDates" CssClass="right"/>
                     </div>
            </div>
            </div>
           
        </form>
    </div>

</body>
</html>
