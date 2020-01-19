<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Activities.aspx.cs" Inherits="Homestead_Project.Add_New_Activity"  EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Activity</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
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
			<h1 class="heading">WELCOME TO THE ACTIVITIES PAGE</h1>
        </div>
        		<form id="form1" runat="server">
       
			<div class="point-box">
				<div class="container">

                    <asp:Label runat="server" ID="menuHeading" Text="Activities Page </br> Click buttons below to view all current activites, update activities or add a new activity " Font-Size="20px" Font-Bold="true"/>
                    <hr style="width:800px;"/>
                    <br/>
                    
                    <br/>
                    <br/>
                    <asp:label ID="newActlbl" runat="server" Text= "Click this button if you want to add a new activity  <br />" Font-Size="18px" />
                    <br />
                    <asp:Button runat="server" Text="Add New Activity" CssClass="buttons" ID="addActivityBtn" OnClick="AddActivity" Height="40px" Width="280px"/>
                    <br/>
                    <br/>
                    <br/>
                    <asp:label ID="viewActLbl" runat="server" Text= "Click this button if you want to either view or update specific activities  <br />" Font-Size="18px" />
                        <br />
                    <asp:Button runat="server" Text="View the Activities" CssClass="buttons" ID="viewActivitiesBtn" OnClick="viewActivitiesBtn_Click" Height="40px" Width="280px"/>
                 <br />
                    <asp:label ID="exitLbl" runat="server" Text= "" Font="Arial" Font-Size="20px" Font-Bold="true" ForeColor ="Blue"/>
                    <br />
                    <asp:Button runat="server" Text="Exit" CssClass="buttons" ID="exitBtn" OnClick="exitBtn_Click" Height="40px" Width="280px" />

                    <h4><asp:Label runat="server" ID="viewActivitiesHeading" Text="Do you want to view the activities that are either occupied, unoccupied or both:" Visible="false" > </asp:Label>
                            <asp:DropDownList ID="activityStatusOptions" runat="server" CssClass="combo-box" AutoPostBack="True" OnSelectedIndexChanged="activityStatusOptions_SelectedIndexChanged" Visible="false">
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>Inactive</asp:ListItem>
                            <asp:ListItem>All</asp:ListItem>
                        </asp:DropDownList>
                    </h4>

                    <asp:GridView ID="activityList" runat="server" AutoGenerateColumns ="false" DataKeyNames = "activityID" Visible="false"
                        ShowHeaderWhenEmpty = "true">

                        <Columns>
                            <asp:TemplateField HeaderText ="Activity Name">
                                <ItemTemplate>
                                    <asp:Label Text = '<%# Eval("activityDescription") %>' runat ="server"/>
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText ="Active/Inactive">
                                <ItemTemplate>
                                    <asp:Label Text = '<%# Eval("statusDescription") %>' runat ="server"/>
                                </ItemTemplate>

                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText ="Location">
                                <ItemTemplate>
                                    <asp:Label Text = '<%# Eval("facilityName") %>' runat ="server"/>
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText ="Points Worth">
                                <ItemTemplate>
                                    <asp:Label Text = '<%# Eval("activityPointAllocation") %>' runat ="server"/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText ="Date">
                                <ItemTemplate>
                                    <asp:Label Text = '<%# Eval("activityDate") %>' runat ="server"/>
                                </ItemTemplate>

                            </asp:TemplateField>

                             <asp:TemplateField HeaderText ="Time">
                                <ItemTemplate>
                                    <asp:Label Text = '<%# Eval("activityTime") %>' runat ="server"/>
                                </ItemTemplate>

                            </asp:TemplateField>


                            <asp:TemplateField>
                                <ItemTemplate>                                  
                                    <asp:LinkButton ID = "editBtn" CommandArgument='<%# Eval("activityID") %>' runat="server" Text = "Edit" OnClick="EditAnActivity" CssClass="buttons" Height="20px" Width="80px"/>
                                 </ItemTemplate>           

                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>
                    <br />
                    <asp:Button ID="exitViewingBtn" runat="server" Text="Finish Viewing" CssClass ="buttons" Height="40px" Width="280px" OnClick="exitViewingBtn_Click" Visible = "false"/>

                    <asp:Label ID = "successLblMessage" Text = "" runat = "server" ForeColor = "Green" />
                    <br />
                    <asp:Label ID = "errorLblMessage" Text = "" runat = "server" ForeColor = "Red" />



	
					<div class="form" runat="server" Visible="false" id="AddActivityForm">
						<legend><span class="number">2</span> Input Activity Information Below</legend>
						<div class="inner-wrap">							
							<asp:Label runat="server" Text="Activity Name:" CssClass="label" />
							<asp:TextBox runat="server" ID="activityName" CssClass="textInputs"/>
                            <asp:Label ID="entryAOne" runat="server" Text="Required" ForeColor = "Red" Visible="false"></asp:Label>
                            <br/>
                            <br/>
                            <asp:Label runat="server" Text="Facility Location" CssClass="label"/>
                            <asp:dropdownlist runat="server" CssClass="textInputs" ID="addFacilityOptions">
                            </asp:dropdownlist>
                            <br/>
                            <br/>
                            <asp:Label ID="entryATwo" runat="server" Text="Required" ForeColor = "Red" Visible="false"></asp:Label>

                            <br/>
                            <br/>
							<asp:Label runat="server" Text="Point Worth" CssClass="label"/>
							<asp:TextBox runat="server" ID="pointsAllocatedTxt" CssClass="textInputs" TextMode="Number"/>
                            <asp:Label ID="entryAThree" runat="server" Text="Required" ForeColor = "Red" Visible="false"></asp:Label>
                            <br/>
                            <br/>
                            <asp:Button runat="server" Text="Save" ID="btnSave" CssClass="buttons" OnClick="SaveActivity" Height="40px" Width="280px"/>
                            <asp:Button runat="server" Text="Cancel" ID="cancelAddBtn" CssClass="buttons" OnClick="cancelAddBtn_Click" Height="40px" Width="280px"/>
                         </div>
					</div>

                    <div class="form" runat="server" Visible="false" id="UpdateActivityForm">
						<legend><span class="number">2</span> Update Activity Information Below</legend>
						<div class="inner-wrap">
                            <asp:TextBox ID="activityIDTxt" runat="server" Visible="False"></asp:TextBox>
							<asp:Label runat="server" Text="Activity Name:" CssClass="label" />
							<asp:TextBox runat="server" ID="uActivityNameTxt" CssClass="textInputs"/>
                            <asp:Label ID="entryUOne" runat="server" Text="Required" ForeColor = "Red" Visible="false"></asp:Label>
                            <asp:Label runat="server" Text="Facility Location" CssClass="label"/>
                            <asp:dropdownlist runat="server" CssClass="textInputs" ID="updateFacilityOptions">
                            </asp:dropdownlist>
                            <asp:Label ID="entryUTwo" runat="server" Text="Required" ForeColor = "Red" Visible="false"></asp:Label>
                            <asp:Label ID="uActivityNameExist" runat="server" Text="" CssClass="label" Visible="false"/>
                            <br/>  
                           
                            <asp:Label runat ="server" Text="Activity Status" CssClass="label"/>
                            <asp:dropdownlist runat="server" CssClass="textInputs" ID="uActivityStatus" OnSelectedIndexChanged="uActivityStatus_SelectedIndexChanged" AutoPostBack="true"></asp:dropdownlist>
                            <asp:Label ID="entryUThree" runat="server" Text="Required" ForeColor = "Red" Visible="false"></asp:Label>
                            <br/>
                            <form action ="/action_page.php">
                                <asp:Label runat="server" ID="dateHeadingLbl" Text="Date of the activity" CssClass="label"/>
                                <asp:Button runat="server" Text="Select Date" ID="uSelectDatebtn" CssClass="buttons" OnClick="uDateBtn_Click" Height="40px" Width="280px"/>
                                <br />
                                <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" Visible ="false"></asp:Calendar>
                                <br/>
                                <asp:TextBox ID ="uDateTxt" runat = "server" ReadOnly="True" CssClass="textInputs"></asp:TextBox>
                                <asp:Label ID="entryUFour" runat="server" Text="Required" ForeColor = "Red" Visible="false"></asp:Label>
                            </form>
                            <asp:Label runat="server" Text="Activity Time:" CssClass="label" ID="uTimeLabel" />
							<asp:TextBox runat="server" ID="uTimeTxt" CssClass="textInputs" TextMode="Time">00:00</asp:TextBox>
                            <asp:Label ID="entryUFive" runat="server" Text="Required" ForeColor = "Red" Visible="false"></asp:Label>
                            <br/>
                            <br/>
							<asp:Label runat="server" Text="Point Worth" CssClass="label"/>
							<asp:TextBox runat="server" ID="uPointsTxt" CssClass="textInputs" TextMode="Number"/>
                            <asp:Label ID="entryUSix" runat="server" Text="Required" ForeColor = "Red" Visible="false"></asp:Label>
                            <br/>
                            <asp:Button runat="server" Text="Update" ID="updateBtn" CssClass="buttons" OnClick="UpdateActivity" Height="40px" Width="280px"/>
                            <asp:Button ID="cancelBtn" runat="server" Text="Cancel" CssClass="buttons" OnClick="CancelUpdate" Height="40px" Width="280px"/>
                         </div>
					</div>
					
				</div>
										
			</div>
	
		</form>
	</div>
    
</body>
</html>

