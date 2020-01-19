<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Planner.aspx.cs" Inherits="Homestead_Project.Planner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <div class="main">
         <div class="hero-image">
			<h1 class="heading">Planner</h1>
        </div>
        <form id="form1" runat="server">
            <div class="planner-box">
                <div class="container">
                    <div class="planner-div">
                              <asp:Calendar ID="Calendar1" runat="server" CssClass="calendar" SelectionMode="Day" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                    <div class="view-buttons">
                        <asp:Button ID="btnNewEvent" runat="server" Text="Add New Activities" OnClick="NewActivity" CssClass="buttons"/>
                    <asp:Button ID="btnViewSchedule" runat="server" Text="View Schedule" OnClick="ShowDiv" CssClass="buttons"/>
                    </div>
                    
                    <div class="current-schedule">
                        <h3>Current Task for the Day:</h3>
                        <br />
                        <hr style="width:600px;"/>
                        <h3>Extra Mural Activities</h3>
                        <br />
                        <asp:Label runat="server" ID="lblDate"  CssClass="texts"/>
                        <br />
                         <h3>Court Dates</h3>
                        <br />
                        <asp:Label runat="server" ID="lblTime"  CssClass="texts" /> 
                        <br />
                         <h3>Birthdays</h3>
                        <br />
                        <asp:Label runat="server" ID="lblLocation"  CssClass="texts" />
                        <br />
                    </div>
                        
                        
                    <div runat="server" id="schedule" Visible="false">
                        <h3 style="font-weight:bold;">Schedule:</h3>
                        <hr style="width:600px;"/>
                        <h3>Extra Mural Activities</h3>
                        <br />
                        <asp:Label runat="server" ID="txtActivities"  CssClass="texts"/>
                        <br />
                         <h3>Court Dates</h3>
                        <br />
                        <asp:Label runat="server" ID="txtCourtDates"  CssClass="texts" /> 
                        <br />
                         <h3>Birthdays</h3>
                        <br />
                        <asp:Label runat="server" ID="txtBirthdays"  CssClass="texts" />
                        <br />
                        <asp:Label runat="server" ID="txtMonthlySchedule" CssClass="texts"/>
                       
                    
                    </div>
                    </div>
              
                </div>
            </div>
     
    </form>
    </div>
    
</body>
</html>
