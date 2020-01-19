<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register_New_User.aspx.cs" Inherits="Homestead_Project.Register_New_User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register New User</title>
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
		    <h1 class="heading">Register New User </h1>   
        </div>
        <form id="form1" runat="server">
            <div class="point-box">
                <div class="container">
                    <h4>Input All your details Below</h4>
                <hr style="width: 600px;" />
                </div>
                
                <div class="form">
                    <asp:Label runat="server" Text="Please Input your First Name" CssClass="errorMessage" ForeColor="#FF6666" ID="txtError" visible="false"/>
                    <fieldset>
                           <div><legend><span class="number">1</span>Personal Details</legend></div>
                        
                           <div class="inner-wrap">
                        <asp:Label runat="server" text="First Name: " CssClass="label"/>
                               
                        <asp:Textbox runat="server" ID="txtFirstName" CssClass="textInputs" />
                               
               <br />
                        <asp:Label runat="server" text="Surname: " CssClass="label" />
                        <asp:Textbox runat="server" ID="txtSurnname" CssClass="textInputs" />
                     
                        <asp:Label runat="server" text="Date Of Birth" CssClass="label"/>
                        <asp:Textbox runat="server" ID="txtDOB" CssClass="textInputs" />
                      
                        <asp:Label runat="server" text="Gender" CssClass="label"/>
                        <asp:dropdownlist runat="server" CssClass="textInputs" ID="cbGender" OnSelectedIndexChanged="cbGender_SelectedIndexChanged" AutoPostBack="True">
                          
                        </asp:dropdownlist>
                       
                        <asp:Label runat="server" text="Nationality" CssClass="label"/>
                        <asp:dropdownlist runat="server" CssClass="textInputs" ID="cbNationality" OnSelectedIndexChanged="cbNationality_SelectedIndexChanged" AutoPostBack="True">
                          
                        </asp:dropdownlist>
                       
                        <asp:Label runat="server" Text="Contact Number" CssClass="label" />
                        <asp:Textbox runat="server" ID="txtContactNumber" CssClass="textInputs" />

                    </div>
            
                </fieldset>
                <fieldset>
                       <div><legend><span class="number">2</span>Address Details</legend></div>
                        <div class="inner-wrap">
                           <asp:Label runat="server" text="House Number" CssClass="label"/>
                                    <asp:Textbox runat="server" ID="txtHouseNumber" CssClass="textInputs"/>
                               <asp:Label runat="server" text="Street Name" CssClass="label"/>
                                    <asp:Textbox runat="server" ID="txtStreetName" CssClass="textInputs"/>
                                 
                                    <asp:Label runat="server" text="Surburb" CssClass="label" />
                                    <asp:Textbox runat="server" ID="txtSurburb" CssClass="textInputs"/>
                                   
                                    <asp:Label runat="server" text="Town" CssClass="label"/>
                                    <asp:Textbox runat="server" ID="txtTown" CssClass="textInputs"/>
                                
                                    <asp:Label runat="server" text="Postal Code" CssClass="label" />
                                    <asp:Textbox runat="server" ID="txtPostalCode" CssClass="textInputs" />

                                    <asp:Label runat="server" text="Province" CssClass="label"/>
                                    <asp:Textbox runat="server" ID="txtProvince" CssClass="textInputs"/>
                                   </div>    
                </fieldset>
                       <fieldset>
                       <div><legend><span class="number">3</span>Admin Details</legend></div>
                          <div class="inner-wrap"> 
                                                <asp:Label runat="server" Text="Job Title" CssClass="label" />
                        <asp:DropDownList runat="server" CssClass="textInputs" ID="cbJobRole" OnSelectedIndexChanged="cbJobRole_SelectedIndexChanged" AutoPostBack="True">

                        </asp:DropDownList>

                         <asp:Label runat="server" Text="Employee Status" CssClass="label" />
                         <asp:DropDownList runat="server" CssClass="textInputs" ID="cbStatus" OnSelectedIndexChanged="cbStatus_SelectedIndexChanged" AutoPostBack="True">
                           
                        </asp:DropDownList>
                        <br />
                        <asp:Label runat="server" Text="Facilities" CssClass="label" />
                         <asp:DropDownList runat="server" CssClass="textInputs" ID="cbFacilities" OnSelectedIndexChanged="cbFacilities_SelectedIndexChanged" AutoPostBack="True">
                           
                        </asp:DropDownList>  
                               <br />
 
                        <asp:Label runat="server" Text="Email" CssClass="label" />
                        <asp:Textbox runat="server" ID="txtEmail" CssClass="textInputs" />
                        <br />

                        <asp:Label runat="server" Text="Password" CssClass="label" />
                        <asp:Textbox runat="server" ID="txtPassword" CssClass="textInputs" />
                    </div>
                </fieldset>
                    <asp:Button runat="server" text="Register" CssClass="submitButton" OnClick="RegisterNewUser" />
                    </div>
              </form>
                </div>

</body>
</html>
