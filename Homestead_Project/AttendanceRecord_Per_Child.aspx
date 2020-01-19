<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceRecord_Per_Child.aspx.cs" Inherits="Homestead_Project.AttendanceRecord_Per_Child" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendance Record</title>
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
			<h1 class="heading">Attendance Record</h1>
        </div>
		<form id="form1" runat="server">
			<div class="attendance-box" style="width:1200px">
				<div class="container">
					<div id="search">
						<asp:Label runat="server"  CssClass="labels" Text="Full Name:"/>
						<asp:DropDownList runat="server" ID="DropNamesList" CssClass="combo-box"  AutoPostBack="true" OnSelectedIndexChanged="DropNamesList_SelectedIndexChanged">

							
						</asp:DropDownList>
					    <br /> 
                        <br />
					</div>
                

                   <asp:GridView ID="GridView1" ShowHeaderWhenEmpty="true" runat="server" AutoGenerateColumns="false" Width="1200px">
                        <Columns>
                            <asp:BoundField DataField="fileNumber" HeaderText="File Number" />                          
                             <asp:BoundField DataField="childName" HeaderText="Firstname" />
                             <asp:BoundField DataField="childSurname" HeaderText="Lastname" />
                            <asp:BoundField DataField="dailyAttendanceType" HeaderText="Attendances" />
                            <asp:BoundField DataField="datetime" HeaderText="Attendance Dates" />

                        </Columns>
                    </asp:GridView>
                    <br />
					<asp:Label runat="server" Text="Click to view the Monthly Attendance Record for all kids:" CssClass="labels" />
					<asp:Button runat="server" Text="View" CssClass="buttons" ID="viewMonthlyReport" OnClick="viewMonthlyReport_Click" />
                    <br />
				</div>
			</div>
		</form>
	</div>

</body>
</html>

