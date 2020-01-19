<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View_Child_Details.aspx.cs" Inherits="Homestead_Project.View_Child_Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Child Details</title>
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
                <div class="view-details-box">
					<div class="view-grid">
						<div class="container">
							<div id="search" style="margin-left:250px;">
								<asp:Label runat="server" Text="Child Name" CssClass="h"/>
								
                                <asp:dropdownlist id="cbNames" runat="server" CssClass="combo-box" OnSelectedIndexChanged="cbNames_SelectedIndexChanged" AutoPostBack="true">
                                 
                                </asp:dropdownlist>
								
								<br/>
								<asp:Label runat="server" Text="Choose child name to view their details" CssClass="description"/>
							</div>
                    </div>
                      
                    <div class="personal-info">
                                 <h3><i>Personal Information</i></h3>
                                <br />
                    <asp:Label runat="server" Text="Full Name" CssClass="labels"/>
                    <asp:Label runat="server" ID="txtFullName"  CssClass="texts"/>
                    
                    <asp:Label runat="server" Text="Gender" CssClass="labels"/>
                    <asp:Label runat="server" ID="txtGender"  CssClass="texts" />
                  
                    <asp:Label runat="server" Text="Date Of Birth" CssClass="labels"/>
                    <asp:Label runat="server" ID="txtDateOfBirth"  CssClass="texts"/>
                
					<asp:Label runat="server" Text="Age" CssClass="labels"/>
					<asp:Label runat="server" ID="txtAge" Text="20" CssClass="texts"/>
						
					<asp:Label runat="server" Text="School Currently Attending" CssClass="labels" />
					<asp:Label runat="server" ID="txtSchoolName"  CssClass="texts" />
						
                    <asp:Label runat="server" Text="School Contact Number" CssClass="labels" />
					<asp:Label runat="server" ID="txtSchoolContactNumber"  CssClass="texts" />

					<asp:Label runat="server" Text="Extra Mural Activities:" CssClass="labels" />
					<asp:Label runat="server" ID="lblActivities" Text="Hockey" CssClass="texts" />
                 
					<asp:Label runat="server" Text="Nationality" CssClass="labels"/>
					<asp:Label runat="server" ID="txtNationalityChild" Text="South African" CssClass="texts"/>

					<asp:Label runat="server" Text="Legal Status in SA" CssClass="labels" />
					<asp:Label runat="server" ID="txtLegalStatusChild" Text="Citizen" CssClass="texts" />

      
                    </div>
               

            <div class="family-details">
                 <h3><i>Family Details</i></h3>
                <asp:Label runat="server" Text="Full Name" CssClass="labels" />
                <asp:Label runat="server" ID="txtFamilyName"  CssClass="texts"/>
           
                <asp:Label runat="server" Text="Relationship To Child" CssClass="labels"/>
                <asp:Label runat="server" ID="txtRelationship" CssClass="texts"/>
          
                 <asp:Label runat="server" Text="Contact Number" CssClass="labels"/>
                <asp:Label runat="server" ID="txtContactNumber"  CssClass="texts"/>

          
                 <asp:Label runat="server" Text="Address" CssClass="labels"/>
                
                <asp:Label runat="server" ID="txtStreetAddress"  CssClass="texts"/>
                <asp:Label runat="server" ID="txtSurburb"  CssClass="texts" />
                <asp:Label runat="server" ID="txtTown"  CssClass="texts"/>
                <asp:Label runat="server" ID="txtPostalCode" CssClass="texts"/>

            </div>
               
       
                    <div class="admin-info">
                            <h3><i>Admin Info</i></h3>
                 <asp:Label runat="server" Text="Date Of Admission" CssClass="labels"/>
                <asp:Label runat="server" ID="txtAddmissionDate" CssClass="texts"/>
               
                 <asp:Label runat="server" Text="Discharge Date" CssClass="labels"/>
                <asp:Label runat="server" ID="txtDischargeDate"  CssClass="texts"/>
                   
                <asp:Label runat="server" Text="Years In Shelter" CssClass="labels" />
                <asp:Label runat="server" ID="txtYearsInShelter"  CssClass="texts"/>

				 <asp:Label runat="server" Text="Date Order Expires" CssClass="labels"/>
                <asp:Label runat="server" ID="txtCourtOrderDate"  CssClass="texts"/>
                    
                <asp:Label runat="server" Text="Statutory Type" CssClass="labels"/>
                <asp:Label runat="server" ID="txtStatutoryType"  CssClass="texts"/>
                    
                <asp:Label runat="server" Text="Social Worker" CssClass="labels"/>
                <asp:Label runat="server" ID="txtSocialWorkerName" CssClass="texts"/>
               
                <asp:Label runat="server" Text="Childcare Worker" CssClass="labels"/>
                <asp:Label runat="server" ID="txtChildCareWorkerName" CssClass="texts"/>
                  
                <asp:Label runat="server" Text="Shelter Unit" CssClass="labels"/>
                <asp:Label runat="server" ID="txtFacility" CssClass="texts"/>

                <asp:Label runat="server" Text="FileNumber" CssClass="labels" />
				<asp:Label runat="server" ID="txtFileNumber" CssClass="texts" />

				<asp:Button runat="server" Text="View Attendance Record" CssClass="buttons" ID="btnViewAttendance" OnClick="ViewAttendanceRecord"/>
				
                    </div>
					</div>
				
                </div>
          
    </form>
    </div>

</body>
</html>
