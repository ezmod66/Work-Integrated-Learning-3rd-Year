<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HOME_PAGE.aspx.cs" Inherits="Homestead_Project.HOME_PAGE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
     <link href="CSS_SHEET.css" type="text/css" rel="stylesheet" />
     <link href="StyleSheet1.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="JS_FILE.js"></script>
</head>
<body  style="background: url(leaf-background2.png) fixed;">
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
			<h1 class="heading">Homestead Project</h1>
        </div>
        <form id="form1" runat="server">
            
            <div class="menu">
               
                <div class="add-grid">
					<img src="add-icon.png" />
                    <h3 style="font-size:small;">Add New Child Information</h3>
                   <p>Click button below to add new child records</p>
                    <asp:Button runat="server" Text="Open" ID="btnAddNewInfo" CssClass="buttons" Onclick="AddNewDetails"/>

                </div>
                    <div class="add-grid2">
                        <img src="view-icon.png" />
                        <h3 style="font-size:small;">View Children Information</h3>
                        <p>Click button to view the details for a child</p>
                        <asp:Button runat="server" Text="Open" ID="btnViewInformation" CssClass="buttons" OnClick="ViewDetails"/>
                    </div>
        
                <div class="update-grid">
					<img src="update-icon.png" />
                    <h3 style="font-size:small;">Update Child Information</h3>
                    <p>Click button below to update child record</p>
                    <asp:Button runat="server" Text="Open" ID="btnUpdate" CssClass="buttons" OnClick="UpdateDetails"/>
                </div>
                <div class="register-grid">
					<img src="report-icon.png" />
                    <h3 style="font-size:small;">Daily Register</h3>
                    <p>Click button to record daily attendance</p>
                     <asp:Button runat="server" Text="Open" ID="btnDailyRegister" CssClass="buttons" OnClick="OpenRegister"/>
                </div>
                <div class="report-grid">
					<img src="report-icon (2).png" />
                    <h3 style="font-size:small;">Attendance Report Per child</h3>
                    <p>Click button below view a attendance report for each child</p>
                    <asp:Button runat="server" Text="Open" ID="btnAttendanceReportPerChild" CssClass="buttons" OnClick="OpenAttendanceReport"/>
                </div>

                <div class="reportAll-grid">
					<img src="report-icon (2).png" />
                    <h3 style="font-size:small;">Attendance Report For All Kids</h3>
                    <p>Click button below view attendance report for all children</p>
                     <asp:Button runat="server" Text="Open" ID="btnAttendanceReportAllkids" CssClass="buttons" Onclick="OpenAttendanceRecordForAllKids"/>
                </div>
                <div class="currentActivities-grid">
					<img src="activities-icon.png" />
                    <h3 style="font-size:small;">View Current Activities</h3>
                    <p>Click button below to view all current extra mural activities</p>
                     <asp:Button runat="server" Text="Open" ID="btnCurrentActivities" CssClass="buttons" OnClick="OpenCurrentActivities"/>
                </div>
                <div class="attendance-grid">
                    <img src="report-icon (2).png" />
                    <h3 style="font-size:small;">Activity Attendance</h3>
                    <p>Click button below to add new child records</p>
                     <asp:Button runat="server" Text="Open" ID="btnActivityAttendance" CssClass="buttons" OnClick="OpenActivityAttendance"/>
                </div>
                <div class="point-grid">
					<img src="points-icon.png" />
                    <h3 style="font-size:small;">Point System</h3>
                    <p>Click button below to view the point system to view points for each child and how many points each activity is worth</p>
                     <asp:Button runat="server" Text="Open" ID="btnPointSystem" CssClass="buttons" OnClick="OpenPointSystem"/>
 
                </div>
                <div class="planner-grid">
					<img src="planner-icon.png" />
                    <h2>Planner </h2>
                    <asp:Label runat="server" Text="Birthdays: " />
                    <asp:Label runat="server" ID="txtBirthdays" />
                    <br />
                    <asp:Label runat="server" Text="Court Dates" />
                    <asp:Label runat="server" ID="txtCourtDates"/>
                    <br />
                    <asp:Label runat="server" Text="Activities" />
                    <asp:Label runat="server" ID="txtActivities" />
                    <br />
                    <asp:Button runat="server" Text="View Planner" CssClass="buttons" OnClick="OpenPlanner"/>
 
                </div>
            </div>
          
        </form>
    </div>
   
</body>
</html>
